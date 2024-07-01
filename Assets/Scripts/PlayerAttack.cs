using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public ClassTypes Class;
    public GameManager GameManager;



    void Update()
    {
        if (Class == null)
        {
            Class = GameManager.CurrentClass;
        
        }else if (Class == GameManager.Mage)
        {
            attackRange = 4f;
        }
        else if(Class == GameManager.Knight)
        {
            attackRange = 1f;
        }
        else if (Class == GameManager.Hunter)
        {
            attackRange = 0.5f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
    
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
     
}