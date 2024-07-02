using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour
{
    public Inventory Player1;
    public Inventory Player2;
    // Start is called before the first frame update
    void Start()
    {
        Player1 = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player2 = collision.gameObject.GetComponent<Inventory>();
        }
    }
}
