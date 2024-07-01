using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public int attackRange;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public ClassTypes Class;
    public GameManager GameManager;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        
        

    }

    void Update()
    {
        if (Class == null)
        {
            Class = GameManager.CurrentClass;

        }
        else if (Class == GameManager.Mage)
        {
            attackRange = 10;
        }
        else if (Class == GameManager.Knight)
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
    }

    void Attack()
    {
        
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        
        Vector3 attackDirection = (mousePosition - attackPoint.position).normalized;
        Debug.DrawRay(attackPoint.position, attackDirection * attackRange, Color.red, 0.1f);

        
        RaycastHit2D[] hitEnemies = Physics2D.RaycastAll(attackPoint.position, attackDirection, attackRange, enemyLayers);

        foreach (RaycastHit2D hit in hitEnemies)
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

   
}
