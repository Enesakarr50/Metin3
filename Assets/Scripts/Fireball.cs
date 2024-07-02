using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;
    public GameObject impactEffect; // Artýk kullanýlmayacak
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
            }
            TriggerExplosion();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            TriggerExplosion();
        }
    }

    void TriggerExplosion()
    {
        if (!isExploding)
        {
            isExploding = true;
            animator.SetBool("isExploding", true);
            speed = 0; // Hareketi durdur
        }
    }

    // Animasyon sonlandýðýnda bu fonksiyon çaðrýlýr
    public void OnExplosionAnimationEnd()
    {
        Destroy(gameObject);
    }
}
