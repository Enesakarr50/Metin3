using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public int attackRange;
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
            attackRange = 4;
        }
        else if(Class == GameManager.Knight)
        {
            attackRange = 1;
        }
        else if (Class == GameManager.Hunter)
        {
            attackRange = 1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
    
        }
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void Attack()
    {
        RaycastHit2D[] hitEnemies = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position,attackRange,enemyLayers);

        foreach (RaycastHit2D hit in hitEnemies)
        {
            
            hit.collider.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
    }
     
}