using UnityEngine;

public class TreeController : MonoBehaviour
{


    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;
    [SerializeField] private ParticleSystem leafs;

    private bool isCut;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHit() // metodo de bater na arvore
    {
        treeHealth--;
        anim.SetTrigger("isHit");
        leafs.Play();

        if (treeHealth <= 0)
        {
            // cria o toco e instancia os drops(madeira)
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f), transform.rotation);
            }

            anim.SetTrigger("cut");

            isCut = true;
        }
    }

    // faz com que se o player colidir com a arvore e não estiver cortada, chame o metodo de bater na arvore e se estiver cortada não faça nada
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
