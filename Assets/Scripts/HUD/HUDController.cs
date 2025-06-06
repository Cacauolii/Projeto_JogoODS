using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;

    [Header("Tools")]
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;


    private PlayerItems playerItems;
    private Player player;

    // Awake é chamado quando o script é carregado, antes mesmo do start
    private void Awake()
    {
        // Busca o objeto PlayerItems na cena
        // Isso assume que há apenas um PlayerItems na cena
        playerItems = FindFirstObjectByType<PlayerItems>();
        player =  playerItems.GetComponent<Player>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // inicializa as barras de itens em 0
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Atualiza a barra dos itens com base na quantidade atual possiuída
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        woodUIBar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        carrotUIBar.fillAmount = playerItems.carrots / playerItems.carrotsLimit;
        fishUIBar.fillAmount = playerItems.fishes / playerItems.fishesLimits;

        // Atualiza a cor dos ícones das ferramentas com base na ferramenta que está sendo manipulada
        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
