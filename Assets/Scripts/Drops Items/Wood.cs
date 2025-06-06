using UnityEngine;

public class Wood : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move o drop da madeira para direções aleatórias
        timeCount += Time.deltaTime;
        if (timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    
    // Verifica se o player colidiu com o drop da madeira e adiciona a madeira ao inventário do player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItems>().totalWood++;
            Destroy(gameObject);
        }
    }
}
