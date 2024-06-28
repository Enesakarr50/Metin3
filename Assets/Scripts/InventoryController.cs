using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Inventory inventory;
    public Image helmetHolder;
    public Image bodyHolder;
    public Image legHolder;
    public Image weaponHolder;

    private void Start()
    {
        inventory.HelmetHolder = helmetHolder;
        inventory.BodyHolder = bodyHolder;
        inventory.LegHolder = legHolder;
        inventory.WeaponHolder = weaponHolder;
    }
}
