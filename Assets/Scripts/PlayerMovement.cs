using System.Collections;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
        Debug.Log("a");
        Panel = GameObject.FindGameObjectWithTag("Panel");
        animator = GetComponent<Animator>();
        StartCoroutine("cd");
    }

    void Update()
    {
            UpdateAnimation();
            UpdateDirection();

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.C))
            {
                Panel.SetActive(!Panel.activeSelf);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        

        if (isDead)
            return;

        if (health <= 0)
        {
            Die();
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
        Class = GameManager.CurrentClass;
        animator.runtimeAnimatorController = Class.AnimatorController;

        if (movement.magnitude > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void TakeDamage(int damage)
    {
            health -= damage;
            if (health <= 0)
            {
                Die();
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
        
        if (Class != null)
        {
            Debug.Log("anim = " + Class.AnimatorController);
            
        }
    }

}
