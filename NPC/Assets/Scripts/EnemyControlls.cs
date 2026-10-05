using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyControlls : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int life;

    GameObject target;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.gameObject.transform.position, speed * Time.deltaTime);
    }

    void Look()
    {
        if(target.gameObject.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (target.gameObject.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider other)
    {
        if(other.tag == "Hammer")
        {

        }
    }
}
