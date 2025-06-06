using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipalManager : MonoBehaviour
    
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelEntrar;
    [SerializeField] private GameObject painelRegistrar;
    public void JogarEntrar()
    {
        painelMenuInicial.SetActive(false);
        painelEntrar.SetActive(true);
    }
    public void JogarRegistrar()
    {
        painelMenuInicial.SetActive(false);
        painelRegistrar.SetActive(true);

    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
        painelEntrar.SetActive(false);
        painelRegistrar.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}
