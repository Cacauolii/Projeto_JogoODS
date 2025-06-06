using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;
    [SerializeField] private int woodAmount;

    [Header("Components")]
    [SerializeField] private GameObject houseCollider;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;
    
    private bool detectingPlayer;
    private Player player;
    private PlayerAnim playerAnim;
    private PlayerItems playerItems;

    private float timeCount;
    private bool isBeginning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItems.totalWood >= woodAmount)
        {
            // construção é inicializada
            isBeginning = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;
            player.isPaused = true;
            playerItems.totalWood -= woodAmount;

        }

        if (isBeginning)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= timeAmount)
            {
                // casa é finalizada
                playerAnim.OnHammeringEnded();
                houseSprite.color = endColor;
                player.isPaused = false;
                houseCollider.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            detectingPlayer = true;
        }
    }
}
