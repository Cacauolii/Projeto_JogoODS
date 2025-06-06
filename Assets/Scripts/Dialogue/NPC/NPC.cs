using System.Collections.Generic;

using UnityEngine;

public class NPC : MonoBehaviour 
{
[SerializeField] private SpriteRenderer body;
[SerializeField] private SpriteRenderer hair;

        public Vector2 hairPosition1;
        public Vector2 hairPosition2;

        public float speed;

    public float initialSpeed;

    public int index;
    private Animator anim;

public List<Transform> paths = new List<Transform>();

private void Start() 

{

        initialSpeed = speed;
        anim = GetComponent<Animator>();

}


        void Update()

        {

                if (DialogueControl.instance.IsShowing)

                {

                        speed = 0f;
                        anim.SetBool("isWalking", false);

                }

                else
                {

                        speed = initialSpeed;
                        anim.SetBool("isWalking", true);

                }
                transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime); if (Vector2.Distance(transform.position, paths[index].position) < 0.1f) {

                        if (index < paths.Count - 1)

                        {
                                index++;
                        }

                        else
                        {
                                index = 0;
                        }
                }
                Vector2 direction = paths[index].position - transform.position;


                body.flipX = direction.x < 0;
                hair.flipX = direction.x < 0;


                if (direction.x < 0)
                {
                        hair.transform.localPosition = hairPosition2;
                }
                else
                {
                        hair.transform.localPosition = hairPosition1;
                }
        }
 }
