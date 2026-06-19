using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] public float speed;
    [SerializeField] public float lifeTime;

    public bool canMove;

    public Animator anim;

    public static PlayerController instance;

    [Header("Componentes externos")]
    [SerializeField] FixedJoystick moveJoystick;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform posicao;

    




    private void Awake()
    {
        speed = 5;
        canMove = true;

        moveJoystick = FindAnyObjectByType<FixedJoystick>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = GetComponent<GameManager>();
        gameManager = FindAnyObjectByType<GameManager>();
        anim = GetComponent<Animator>();
        speed += gameManager.speedBonus;
        lifeTime += gameManager.timerBonus;
        //posicao = transform.position;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (canMove)
        {
            rb.linearVelocityX = moveJoystick.Horizontal * speed;
            rb.linearVelocityY = moveJoystick.Vertical * speed;
            
        }

        if ((rb.linearVelocityX != 0) || (rb.linearVelocityY != 0))
        {
            ResetLayers();

            anim.SetBool("movendo", true);


        }
        else
        {

            ResetLayers();

            anim.SetBool("movendo", false);
        }


    }

    void Start()
    {
        anim = GetComponent<Animator>();
        //posicao = transform.position;
    }

    void Update()
    {
        Vector2 movimento = new Vector2(transform.position.x, transform.position.y); 

        if (rb.linearVelocityX >= 0.3)
        {
            ResetLayers();
            anim.SetLayerWeight(1, 2);
            spriteRenderer.flipX = false;
        }
        else if (rb.linearVelocityX <= -0.3)
        {
            ResetLayers();
            anim.SetLayerWeight(1, 2);
            spriteRenderer.flipX = true;
        }
        if (rb.linearVelocityY >= 0.3)
        {
            ResetLayers();
            anim.SetLayerWeight(2, 1);
            

        }
        else if (rb.linearVelocityY <= -0.3)
        {
            ResetLayers();
            anim.SetLayerWeight(0, 1);
           

        }

       

       
    }

private void ResetLayers()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
    
    }
}