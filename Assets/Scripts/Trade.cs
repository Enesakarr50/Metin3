using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Trade : MonoBehaviour
{
    
    public Inventory Player1;
    public Inventory Player2;
    public InventoryController mainController;
    public InventoryController secController;
    public GameManager gameManager;
    public ClassTypes Hunter;
    public ClassTypes Knight;
    public ClassTypes Mage;
    // Start is called before the first frame update

    private void Start()
    {
        
        gameManager = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameManager>();
        mainController = GameObject.FindGameObjectWithTag("Gm").GetComponent<InventoryController>();
        Player1.classTypes = gameManager.CurrentClass;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Player2 != null)
        {
            Player1.Helmet = Player2.Helmet;
            Player1.Body = Player2.Body;
            Player1.Leg = Player2.Leg;
            Player1.Weapon = Player2.Weapon;
            Player1.classTypes = Player2.classTypes;
            gameManager.CurrentClass = Player1.classTypes;
            if(gameManager.CurrentClass == Hunter)
            {
                PlayerPrefs.SetInt("ClassEum", (int)Class.Hunter);
            }else if (gameManager.CurrentClass == Knight)
            {
                PlayerPrefs.SetInt("ClassEum", (int)Class.Knight);
            }else if (gameManager.CurrentClass == Mage)
            {
                PlayerPrefs.SetInt("ClassEum", (int)Class.Mage);
            }

        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "npc")
        {
            Debug.Log("s");
            secController = collision.gameObject.GetComponent<InventoryController>();
            Player2 = secController.inventory;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player2 = null;
    }
}
