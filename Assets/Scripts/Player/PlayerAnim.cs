using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private Casting cast;

    [System.Obsolete]
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
    }

    // Update is called once per frame
    void Update()

        {
            OnMove();
            OnRun();
        }

    

    #region Movement

        // e chamado quando o jogador pressiona o botao de açao na lagoa
    public void OnCastingStarted()
    {
        Debug.Log("Começou animaçao de pesca!");
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    //e chamado quando termina de executar a animaçao de pescaria
    public void OnCastingEnded()
    {
        Debug.Log("animaçao de pesca!");
        cast.OnCasting();
        player.isPaused = false;

        anim.Play("idle");
    }


    void OnMove() // metodo de movimento do player
    {
        // Verifica se o player está se movendo
        if (player.direction.sqrMagnitude > 0)
        {
            // Faz com que o player role, se não estiver rolando volta para a animação de movimento
            if (player.isRolling)
            {
                if (!anim.GetAnimatorTransitionInfo(0).IsName("roll"))
                {
                    anim.SetTrigger("isRoll");
                }
            
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
        // Verifica a direção do player e ajusta a rotação
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        // Verifica se o player está cortando madeira, cavando ou regando
        if (player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if (player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if (player.isWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }

    void OnRun() // metodo de correr do player
    {
        if (player.isRunning && player.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 2);
        }
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("hammering" , true);
    }
    
    public void OnHammeringEnded()
    {
        anim.SetBool("hammering", false);
    }

    #endregion
}
