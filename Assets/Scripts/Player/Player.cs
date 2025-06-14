using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   public bool isPaused;
   public bool isLive;
   public string namePlayer = "Raimundo";
   [SerializeField] private float speed;
   [SerializeField] private float runSpeed;

    private Rigidbody2D rig;
    private PlayerItems playerItems;
    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    
    private bool _isDigging;
    private bool _isWatering;

    private Vector2 _direction;

    [HideInInspector] public int handlingObj;
   
   
   
   public Vector2 direction
   {
        get {return _direction;}
        set{ _direction = value;}
   }
   public bool isRunning
   {
        get {return _isRunning;}
        set{ _isRunning = value;}
   }

   public bool isRolling
   {
        get {return _isRolling;}
        set {_isRolling = value;}
   }

    public bool isCutting
    {
        get { return _isCutting;}
        set { _isCutting = value;}
    }
   public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }
    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();
        initialSpeed = speed;
    }
    private void Update()
    {

        if (!isPaused)
        {
             if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObj = 2;
        }


        OnInput();
        OnRun();
        OnRolling();
        OnDig();
        OnCutting();
        OnWatering();
        }
        
    }
    
       

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
    }

    #region Movement

    void OnWatering() // metodo de regar
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
            {
                isWatering = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0) || playerItems.currentWater < 0)
            {
                isWatering = false;
                speed = initialSpeed;
            }

            if (isWatering)
            {
                playerItems.currentWater -= 0.01f;
            }

        }
        else
        {
            isWatering = false;
        }
    }

    void OnCutting() // metodo de cortar arvore
    {
        if (handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCutting = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
        else
        {
            isCutting = false;
        }
    }
    void OnDig() // metodo de cavar
    {
        if (handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDigging = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDigging = false;
                speed = initialSpeed;
            }
        }
        else
        {
            isDigging = false;
        }
        
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove() // faz com que o player vire para a direção que está se movendo
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun() // metodo de correr do player
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
           speed = runSpeed;
           _isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    void OnRolling() // metodo de rolar do player
    {
        if(Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            _isRolling = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }

    #endregion
}
