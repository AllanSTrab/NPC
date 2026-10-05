using System.Collections;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] float speed;

    Vector2 direction;
    bool rolling;

    [Header("Hammer Settings")]
    bool attack;
    [SerializeField] GameObject attackObject;


    Rigidbody2D rb;
    Animator animator;
    Collider2D attackCollider;
    Collider2D colldier2D;

    void Awake()
    {
        attackCollider = attackObject.GetComponent<Collider2D>();
        attackCollider.enabled = false;

        rb = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        colldier2D = GetComponent<Collider2D>();
    }

    void Start()
    {
       
    }

    void Update()
    {
        Move();
        Roll();
        Attack();

        Animations();
    }

    void FixedUpdate()
    {
        OnMove();
    }

    void Move()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(direction.x, 0f);
        }
        else if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(direction.x, 180f);
        }
    }

    void OnMove()
    {
        if (rolling)
        {
            rb.linearVelocity = direction * (speed + 5);
        }
        else
        {
            rb.linearVelocity = direction * speed;
        }
        
    }

    void Roll()
    {
        rolling = Input.GetButtonDown("Jump");

        if(rolling == true)
        {
            StartCoroutine(Invencible());
        }
    }

    IEnumerator Invencible()
    {
        colldier2D.enabled = false;
        yield return new WaitForSeconds(0.75f);
        colldier2D.enabled = true;
        rolling = false;
    }

    void Attack()
    {
        if(attack = Input.GetButtonDown("Fire1") && attack == false)
        {
            StartCoroutine(OnAttack());
        }
    }

    IEnumerator OnAttack()
    {
        attack = true;
        attackCollider.enabled = true;
        yield return new WaitForSeconds(1.15f);
        attackCollider.enabled = false;
        attack = false;
    }

    void Animations()
    {
        animator.SetInteger("pMove", (int)(Mathf.Abs(direction.x) + Mathf.Abs(direction.y)));
        animator.SetBool("pRoll", rolling);
        animator.SetBool("pAttack", attack);
    }
}
