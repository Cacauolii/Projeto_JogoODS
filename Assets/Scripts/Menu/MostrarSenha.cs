using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarSenha : MonoBehaviour
{
    public TMP_InputField campoSenha;
    public Button botaoMostrar;
    public Sprite olhoAberto;
    public Sprite olhoFechado;

    private bool senhaVisivel = false;

    void Start()
    {
        botaoMostrar.onClick.AddListener(TrocarVisibilidade);
        AtualizarIcone();
    }

    void TrocarVisibilidade()
    {
        senhaVisivel = !senhaVisivel;
        campoSenha.contentType = senhaVisivel ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        campoSenha.ForceLabelUpdate(); // Atualiza visualmente
        AtualizarIcone();
    }

    void AtualizarIcone()
    {
        var img = botaoMostrar.GetComponent<Image>();
        if (img != null && olhoAberto != null && olhoFechado != null)
        {
            img.sprite = senhaVisivel ? olhoAberto : olhoFechado;
        }
    }
}
