using Photon.Pun;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun, IPunObservable
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

    public void LStart()
    {
        GameManager = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
        Debug.Log("a");
        Panel = GameObject.FindGameObjectWithTag("Panel");
        animator = GetComponent<Animator>();
        StartCoroutine("cd");
    }

    void Update()
    {
        if (photonView.IsMine)
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
        if (!isDead && photonView.IsMine)
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
            animator.SetBool("isRunning", false);
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

    // IPunObservable implementation
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send data to other players
            stream.SendNext(transform.position);
            stream.SendNext(spriteRenderer.flipX);
            stream.SendNext(animator.GetBool("isRunning"));
            stream.SendNext(health);
            stream.SendNext(Class != null ? Class.ClassNames : "");
        }
        else
        {
            // Receive data from other players
            transform.position = (Vector3)stream.ReceiveNext();
            spriteRenderer.flipX = (bool)stream.ReceiveNext();
            animator.SetBool("isRunning", (bool)stream.ReceiveNext());
            health = (int)stream.ReceiveNext();

            string className = (string)stream.ReceiveNext();
            if (Class == null || Class.ClassNames != className)
            {
                Class = GameManager.CurrentClass;
                if (Class != null)
                {
                    animator.runtimeAnimatorController = Class.AnimatorController;
                }
            }
        }
    }
}
