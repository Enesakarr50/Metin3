using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;
    private Animator animator;
    private bool isExploding = false;

    void Start()
    {
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
        if (collision.CompareTag("Obstacle"))
        {
            speed = 0;
            TriggerExplosion();
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
