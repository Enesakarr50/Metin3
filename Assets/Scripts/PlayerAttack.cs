using System.Collections;
using System.Collections.Generic;
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
    public bool CanShoot;

    private Camera mainCamera;
    private void Awake()
    {
        GameManager = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
    }

    private void Start()
    {
        CanShoot = true;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(attackDamage < GameManager.GetComponent<InventoryController>().inventory.Ilvl)
        {
            attackDamage += GameManager.GetComponent<InventoryController>().inventory.Ilvl;
        }
        Class = GameManager.CurrentClass;
        

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

            if (Class == GameManager.Mage && CanShoot == true)
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
        

        RaycastHit2D[] hitEnemies = Physics2D.RaycastAll(attackPoint.position, attackDirection, attackRange, enemyLayers);

        foreach (RaycastHit2D hit in hitEnemies)
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        
    }

    void Shoot()
    {
        
        CanShoot = false;
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 shootDirection = (mousePosition - firePoint.position).normalized;

        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = shootDirection * fireballSpeed;
        }

        // Fireball'un yönünü ayarla
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        fireball.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        StartCoroutine("As");


    }
    public IEnumerator As()
    {
        
        yield return new WaitForSeconds(0.5f);
        CanShoot = true;

    }
}
