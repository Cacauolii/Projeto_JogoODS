using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
    
{
    [SerializeField] private GameObject painelMenuPause;
    [SerializeField] private GameObject painelOpcoes;
   
    public GameObject botaoSalvar;
    public GameObject botaoOpcoes;
    public GameObject botaoMenuPrincipal;

    private bool menuAtivo = false;

    void Start()
    {
        painelMenuPause.SetActive(false);
        painelOpcoes.SetActive(false);
    }

void Update()
{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuAtivo = !menuAtivo; // Alterna o estado do menu

            painelMenuPause.SetActive(menuAtivo); // Ativa ou desativa o painel de menu
            botaoSalvar.SetActive(menuAtivo);
            botaoOpcoes.SetActive(menuAtivo);
            botaoMenuPrincipal.SetActive(menuAtivo);    // Alterna visibilidade
        }
}
   

    public void AbrirOpcoes()
    {
        painelMenuPause.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuPause.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Tela Inicial");

    }

}
