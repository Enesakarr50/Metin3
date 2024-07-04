using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private bool isExploding = false;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        if (!isExploding)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int damage = Player.GetComponent<PlayerAttack>().attackDamage;
        if (collision.CompareTag("Obstacle"))
        {
            speed = 0;
            TriggerExplosion();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                speed = 0;
                enemy.TakeDamage(damage);
                TriggerExplosion();
            }
        }


    }



    void TriggerExplosion()
    {
        if (!isExploding)
        {
            isExploding = true;
            

            // Patlama animasyonunu oynat
            if (animator != null)
            {
                animator.SetTrigger("isExploding");
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }
            else
            {
                
                Destroy(gameObject);
            }
        }
    }
}
