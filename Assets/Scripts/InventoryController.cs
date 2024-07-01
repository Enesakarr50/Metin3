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
    private void Update()
    {
        inventory.HelmetHolder = helmetHolder.sprite;
        inventory.BodyHolder = bodyHolder.sprite;
        inventory.LegHolder = legHolder.sprite;
        inventory.WeaponHolder = weaponHolder.sprite;
    }
}
