using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    public ClassTypes Class;
    public GameManager GameManager;
    public GameObject Panel;
    public int health = 100;

    public Animator animator;
    private bool isDead = false;
    private SpriteRenderer spriteRenderer;

    
    private void Awake()
    {
        
    }
    public void LStart()
    {

        GameManager = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
        Debug.Log("a");
        Panel = GameObject.FindGameObjectWithTag("Panel");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("cd");

    }
    

    void Update()
    {
        if (isDead)
            return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.C))
        {
            Panel.SetActive(!Panel.activeSelf);

        }

        if (health <= 0)
        {
            Die();
        }

        UpdateAnimation();
        UpdateDirection();

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void UpdateAnimation()
    {
        if (movement.magnitude > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            //animator.SetBool("isRunning", false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            health -= damage;
            animator.SetTrigger("Hurt");
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void UpdateDirection()
    {
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        
    }

    void Attack()
    {
       
        animator.SetTrigger("Attack");
    }
    IEnumerator cd()
    {
        yield return new WaitForSeconds(0.1f);
        Class = GameManager.CurrentClass;
        if (Class != null)
        {
            Debug.Log("anim = " + Class.AnimatorController);
            animator.runtimeAnimatorController = Class.AnimatorController;
            
        }

    }
}
