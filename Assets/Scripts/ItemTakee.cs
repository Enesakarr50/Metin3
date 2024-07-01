using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTakee : MonoBehaviour
{
    public InventoryController invCont;
    public Item Item;
    public GameObject Gm;

    private void Start()
    {
        Gm = GameObject.FindGameObjectWithTag("Gm");
        invCont = Gm.GetComponent<InventoryController>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch (Item.ItemType)
            {
                case ItemType.Helmet:
                    Destroy(gameObject);
                    invCont.helmetHolder.sprite = Item.ItemImage;
                    invCont.Helmet = Item;
                    invCont.iLvl += Item.ItemLvl;

                    break;
                case ItemType.Chestplate:
                    Destroy(gameObject);
                    invCont.bodyHolder.sprite = Item.ItemImage;
                    invCont.Cp = Item;
                    invCont.iLvl += Item.ItemLvl;

                    break;
                case ItemType.Legplate:
                    Destroy(gameObject);
                    invCont.legHolder.sprite = Item.ItemImage;
                    invCont.Lp = Item;
                    invCont.iLvl += Item.ItemLvl;
                    break;
                case ItemType.Weapon:
                    Destroy(gameObject);
                    invCont.weaponHolder.sprite = Item.ItemImage;
                    invCont.Weap = Item;
                    invCont.iLvl += Item.ItemLvl;
                    break;
            }
        }
       
    }
}
