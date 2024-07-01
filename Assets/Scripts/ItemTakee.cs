using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTakee : MonoBehaviour
{
    public Inventory Inv;
    public Item Item;

    private void Start()
    {
        Item = GetComponent<Item>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
