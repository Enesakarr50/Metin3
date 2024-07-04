using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int initHealth;
    public GameObject[] itemPrefab;
    public float speed = 3.0f;
    public float attackRange = 2.0f;
    public int attackDamage = 10;
    public float attackCooldown = 2.0f;
    public Image HealthBar;
    public Vector3 direction;


    private Transform playerTransform;
    private Animator animator;
    private float attackTimer;
    public bool isDead = false;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;
    public GameManager gm;
    public bool Suicede;
    public bool isKnockBacking;


 
    

    private void Start()
    {
  
        gm = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = playerTransform.GetComponent<PlayerMovement>(); // PlayerMovement script'ine eriþim
        initHealth = health;
    }

    private void Update()
    { 
        if (isDead) return;

        attackTimer -= Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        HealthBar.fillAmount = (float)health / (float)initHealth;

        if (distanceToPlayer <= attackRange)
        {
            if (attackTimer <= 0f)
            {
                Attack();
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
        direction = (playerTransform.position - transform.position).normalized;
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

    private void Attack()
    {
        animator.SetBool("isAttacking", true);
        if (playerMovement != null) 
        {
            playerMovement.TakeDamage(attackDamage);
        }
        if (Suicede == true)
        {
            Destroy(gameObject,1f);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        animator.SetTrigger("Hurt");
        if(isKnockBacking == false)
        {
            speed = -speed;
            isKnockBacking = true;
            StartCoroutine("knockBack");
            if (health <= 0 && isDead == false)
            {
                Die();
            }
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
            int drpp = Random.Range(0, 6);
            if (drpp == 0)
            {
                int intex = Random.Range(0, itemPrefab.Length);
                Debug.Log(intex);
                if (itemPrefab[intex].GetComponent<ItemTakee>().Item.Class == gm.CurrentClass.s)
                {
                    itemPrefab[intex].GetComponent<ItemTakee>().Item.ItemLvl = (gm.GetComponent<InventoryController>().iLvl) / 4;
                }
                else if (itemPrefab[intex].GetComponent<ItemTakee>().Item.Class != gm.CurrentClass.s)
                {
                    itemPrefab[intex].GetComponent<ItemTakee>().Item.ItemLvl = 0;
                }
                
                Instantiate(itemPrefab[intex], transform.position, Quaternion.identity);
            }
           
        }
        Destroy(gameObject, 2f); // Ölüm animasyonunu oynatmak için bir gecikme ekleyin
    }

    IEnumerator knockBack()
    {
        yield return new WaitForSeconds(0.3f);
        isKnockBacking = false;
        speed = -speed;
    }
}
