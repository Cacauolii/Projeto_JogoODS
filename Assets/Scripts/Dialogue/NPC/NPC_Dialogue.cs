
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerlayer;
    public Vector2 offset;

    public DialogueSettings dialogue;
    bool playerHit; 

  private List<string> sentences = new List<string>(); 
  private List<string> actorName = new List<string>();
  private List<Sprite> actorSprite = new List<Sprite>();

    private void Start()
    {
        GetNPCInfo();
    }

    void Update()
        {
            if(Input.GetKeyDown(KeyCode.E) && playerHit)
        
            {
                DialogueControl.instance.Speech(sentences.ToArray(), actorName.ToArray(), actorSprite.ToArray());
                
            }
        }
        
        void GetNPCInfo()
        {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;

                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }

            actorName.Add(dialogue.dialogues[i].actorName);
            actorSprite.Add(dialogue.dialogues[i].profile);
              
              

                
            }
        }
        

    // e usado pela fisica
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerlayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 circlePosition = (Vector2)transform.position + offset;
        Gizmos.DrawWireSphere(circlePosition, dialogueRange);
    }

}
