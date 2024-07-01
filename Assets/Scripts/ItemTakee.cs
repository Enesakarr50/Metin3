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
        if(Item.ItemType == ItemType.Helmet)
        {
            Destroy(gameObject);
            invCont.helmetHolder.sprite = Item.ItemImage;
        }
        else if (Item.ItemType == ItemType.Chestplate)
        {
            Destroy(gameObject);
            invCont.bodyHolder.sprite = Item.ItemImage;
        }
        else if (Item.ItemType == ItemType.Legplate)
        {
            Destroy(gameObject);
            invCont.legHolder.sprite = Item.ItemImage;
        }
        else if (Item.ItemType == ItemType.Weapon)
        {
            Destroy(gameObject);
            invCont.weaponHolder.sprite = Item.ItemImage;
        }
    }
}
