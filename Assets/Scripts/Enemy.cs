using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject itemPrefab;
    public float speed = 3.0f; // Düþmanýn hareket hýzý
    public float attackRange = 2.0f; // Saldýrý menzili
    public int attackDamage = 10; // Saldýrý hasarý
    public float attackCooldown = 2.0f; // Saldýrý bekleme süresi

    private Transform playerTransform;
    private Animator animator;
    private float attackTimer;
    private bool isDead = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isDead) return;

        attackTimer -= Time.deltaTime;
        
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer <= attackRange)
        {
            if (attackTimer <= 0f)
            {
                animator.SetBool("isAttacking", true);
                attackTimer = attackCooldown;
            }
            animator.SetBool("isWalking", false);
        }
        else
        {
            MoveTowardsPlayer();
        }
        UpdateDirection();
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
    }

    private void UpdateDirection()
    {
        if (playerTransform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (playerTransform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        if (health <= 0 && isDead == false)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetBool("isDead", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", false);

        if (itemPrefab != null)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject, 2f); // Ölüm animasyonunu oynatmak için bir gecikme ekleyin
    }
}
