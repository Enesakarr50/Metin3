using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject Item;
    public Item itemindex;


    private void Start()
    {
            Item.GetComponent<SpriteRenderer>().sprite = itemindex.ItemImage;
            
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
        Instantiate(Item, transform.position, Quaternion.identity);
        if (Random.value < 0.5f)
        {
            
        }
        Destroy(gameObject);
        
    }

  
}
