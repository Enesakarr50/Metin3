using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public ClassTypes Class;
    public GameManager GameManager;
    public Transform firePoint; // Fireball'un fýrlatýlacaðý nokta
    public GameObject fireballPrefab; // Fireball prefab'i
    public float fireballSpeed = 10f; // Fireball'un hýzý

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

        if (Class == GameManager.Mage)
        {
            attackRange = 10f;
        }
        else
        {
            attackRange = 1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();

            if (Class == GameManager.Mage)
            {
                Shoot();
            }
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

    void Shoot()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 shootDirection = (mousePosition - firePoint.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, shootDirection);

        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = shootDirection * fireballSpeed;
        }
    }
}
