using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Inventory inventory;
    public Image helmetHolder;
    public Image bodyHolder;
    public Image legHolder;
    public Image weaponHolder;
    public Item Helmet;
    public Item Cp;
    public Item Lp;
    public Item Weap;

    private void Update()
    {
        inventory.HelmetHolder = helmetHolder.sprite;
        inventory.BodyHolder = bodyHolder.sprite;
        inventory.LegHolder = legHolder.sprite;
        inventory.WeaponHolder = weaponHolder.sprite;
        inventory.Helmet = Helmet;
        inventory.Body = Cp;
        inventory.Leg = Lp;
        inventory.Weapon = Weap;
    }
}
