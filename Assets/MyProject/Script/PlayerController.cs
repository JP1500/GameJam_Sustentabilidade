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
    bool canMoveLeft;
    bool canMoveRight;
    bool canMoveUp;
    bool canMoveDown;

    public Animator anim;

    public static PlayerController instance;

    [Header("Componentes externos")]
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        speed = 5;
        canMove = true;
        canMoveLeft = false;
        canMoveRight = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = GetComponent<GameManager>();
        gameManager = FindAnyObjectByType<GameManager>();
        anim = GetComponent<Animator>();
        speed += gameManager.speedBonus;
        lifeTime += gameManager.timerBonus;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (canMove)
        {
            if (canMoveLeft && !canMoveRight && !canMoveUp && !canMoveDown)
            {
                rb.linearVelocityX = -speed;
            }

            else if (!canMoveLeft && canMoveRight && !canMoveUp && !canMoveDown)
            {
                rb.linearVelocityX = speed;
            }
            else if (!canMoveLeft && !canMoveRight && canMoveUp && !canMoveDown)
            {
                rb.linearVelocityY = speed;
            }
            else if (!canMoveLeft && !canMoveRight && !canMoveUp && canMoveDown)
            {
                rb.linearVelocityY = -speed;
            }
            else
            {
                rb.linearVelocityX = 0f;
                rb.linearVelocityY = 0f;
            }
        }

    }

    public void MoveLeft()
    {
        if (canMove)
        {
            canMoveLeft = true;
            ResetLayers();
            anim.SetLayerWeight(1, 2);
            anim.SetBool("movendo", true);
            spriteRenderer.flipX = true;
        }
    }
    public void StopMoveLeft()
    {
        if (canMove)
        {
            canMoveLeft = false;
            ResetLayers();
            anim.SetLayerWeight(1, 2);
            anim.SetBool("movendo", false);
        }
    }
    public void MoveRight()
    {
        if (canMove)
        {
            canMoveRight = true;
            ResetLayers();
            anim.SetLayerWeight(1, 2);
            anim.SetBool("movendo", true);
            spriteRenderer.flipX = false;
        }
    }
    public void StopMoveRight()
    {
        if (canMove)
        {
            canMoveRight = false;
            ResetLayers();
            anim.SetLayerWeight(1, 2);
            anim.SetBool("movendo", false);
        }
    }
    public void MoveUp()
    {
        if (canMove)
        {
            canMoveUp = true;
            ResetLayers();
            anim.SetLayerWeight(2, 1);
            anim.SetBool("movendo", true);
        }
    }
    public void StopMoveUp()
    {
        if (canMove)
        {
            canMoveUp = false;
            ResetLayers();
            anim.SetLayerWeight(2, 1);
            anim.SetBool("movendo", false);
        }
    }
    public void MoveDown()
    {
        if (canMove)
        {
            canMoveDown = true;
            ResetLayers();
            anim.SetLayerWeight(0, 0);
            anim.SetBool("movendo", true);
        }
    }
    public void StopMoveDown()
    {
        if (canMove)
        {
            canMoveDown = false;
            ResetLayers();
            anim.SetLayerWeight(0, 0);
            anim.SetBool("movendo", false);
        }
    }

    private void ResetLayers()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
    
    }
}