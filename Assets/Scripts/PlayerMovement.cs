using UnityEditor.Animations;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    public ClassTypes Class;
    public GameManager GameManager;


    private void Start()
    {
        
    }

    void Update()
    {
        if (Class == null)
        {
            Class = GameManager.CurrentClass;
          //  gameObject.GetComponent<SpriteRenderer>().sprite = Class.CharSprite;
          gameObject.GetComponent<Animator>().runtimeAnimatorController = Class.AnimatorController;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
}