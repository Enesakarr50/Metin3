using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject lootPrefab;


    private void Start()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        if (Random.value < 0.5f)
        {
            
        }
        Destroy(gameObject);
        
    }

  
}
