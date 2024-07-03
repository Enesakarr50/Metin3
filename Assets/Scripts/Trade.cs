using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour
{
    public Inventory Player1;
    public Inventory Player2;
    public Inventory waiting;
    public InventoryController mainController;
    public InventoryController secController;
    // Start is called before the first frame update

    private void Start()
    {
        mainController = GameObject.FindGameObjectWithTag("Gm").GetComponent<InventoryController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Player2 != null)
        {
            waiting = Player1;
            Player1 = Player2;
            Player2 = waiting;
            mainController.inventory = Player1;
            secController.inventory = Player2;
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "npc")
        {
            secController = collision.gameObject.GetComponent<InventoryController>();
            Player2 = secController.inventory;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player2 = null;
    }
}
