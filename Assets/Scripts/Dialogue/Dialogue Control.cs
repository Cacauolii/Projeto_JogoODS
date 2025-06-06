using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
public class DialogueControl : MonoBehaviour

{ 
  [System.Serializable]
  public enum idiom

{
  pt,
  eng,
  spa
}

 public idiom language;


[Header("Components")]
public GameObject dialogueObj;//janela do dialogo
public Image profileSprite;//sprite do perfil
public TextMeshProUGUI speechText;//texto da fala
public TextMeshProUGUI ActorNameText;//nome do npc


[Header("Settings")]
 public float typingSpees; //velocidade da fala

 //Variaveis de controle
 private bool isShowing; //sew a janela esta visivel
 private int index; //index das sentenças 
 private string[] sentences;
 private string[] currentActorName;
 private Sprite[] actorSprite;

  private Player player;

 public static DialogueControl instance;

 public bool IsShowing { get => isShowing; set => isShowing = value; }
 
 
 //awake e chamado antes de todos os start() na hierarquia de execuçao de scripts
  private void Awake()
  {
    instance = this;
  }

    [System.Obsolete]
    void Start()
    {
        player = FindObjectOfType<Player>(); 
    }

    
    IEnumerator TypeSetence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
           speechText.text += letter;
           yield return new WaitForSeconds(typingSpees);

        }
    }

    //pular para proxima frase/fala
     public void NextSetence()
     {
       if (speechText.text == sentences[index])
      {
      if (index < sentences.Length - 1)
      {
        index++;
        profileSprite.sprite = actorSprite[index];
        ActorNameText.text = currentActorName[index];
        speechText.text = "";
        StartCoroutine(TypeSetence());
      }
      else//quando terminam os textos
      {
        speechText.text = "";
        ActorNameText.text = "";
        index = 0;
        dialogueObj.SetActive(false);
        sentences = null;
        isShowing = false;
        player.isPaused = false;
           }
      }
     }
    
    //chamar a fala do npc
     public void Speech(string[] txt,string[]actorName, Sprite [] actorProfile)
     {
    if (!isShowing)
    {
      dialogueObj.SetActive(true);
      sentences = txt;
      currentActorName = actorName;
      actorSprite = actorProfile;
      profileSprite.sprite = actorSprite[index];
      ActorNameText.text = currentActorName[index];
      StartCoroutine(TypeSetence());
      isShowing = true;
      player.isPaused = true;
       }
     }
}
