using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    public ClassTypes Class;
    public GameManager GameManager;
    public GameObject Panel;
    public int health = 100;
    public int initHealth = 100;
    public Image healthBar;

    public Animator animator;
    private bool isDead = false;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
        Panel = GameObject.FindGameObjectWithTag("Panel");
    }

    public void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
        Debug.Log("a");
        Panel.SetActive(false);
        animator = GetComponent<Animator>();
        StartCoroutine("cd");

        health = initHealth;
        UpdateHealthBar();
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

        UpdateHealthBar();
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

    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)health / (float)initHealth;
    }

    void UpdateDirection()
    {
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        StartCoroutine(Respawn());
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

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f); // 2 saniye bekle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden y�kle
    }
}
