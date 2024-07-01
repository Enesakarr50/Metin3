using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f; 
    public int damage = 20; 
    public GameObject impactEffect; 

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); 
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
            DestroyFireball();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            DestroyFireball(); 
        }
    }

    void DestroyFireball()
    {
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation); 
        }
        Destroy(gameObject); 
    }
}
