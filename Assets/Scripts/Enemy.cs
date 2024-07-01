using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Item Item;


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
        Instantiate(Item.GameObject, transform.position, Quaternion.identity);
        if (Random.value < 0.5f)
        {
            
        }
        Destroy(gameObject);
        
    }

  
}
