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
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                TriggerExplosion();
            }
            
        }

        if(collision.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == ("Obstacle"))
        {
            TriggerExplosion();
        }
    }



    void TriggerExplosion()
    {
        if (!isExploding)
        {
            isExploding = true;
            
            speed = 0;
            Destroy(gameObject);
        }
    }

    
}
