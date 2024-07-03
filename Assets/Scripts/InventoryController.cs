using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public bool isNPC;
    public Inventory inventory;
    public Image helmetHolder;
    public Image bodyHolder;
    public Image legHolder;
    public Image weaponHolder;
    public Item Helmet;
    public Item Cp;
    public Item Lp;
    public Item Weap;
    public TextMeshProUGUI IlvlTxt;
    public int iLvl;

    private void Start()
    {
        iLvl = inventory.Ilvl;
    }
    private void Update()
    {

        if (isNPC == false)
        {
            inventory.HelmetHolder = helmetHolder.sprite;
            inventory.BodyHolder = bodyHolder.sprite;
            inventory.LegHolder = legHolder.sprite;
            inventory.WeaponHolder = weaponHolder.sprite;
            Helmet= inventory.Helmet;
            Cp = inventory.Body;
            Lp = inventory.Leg;
            Weap = inventory.Weapon;
            if(Helmet != null)
            {
                helmetHolder.sprite = Helmet.ItemImage;
            }
            else
            {
                helmetHolder.sprite = null;
            }
            if(Cp != null)
            {
                bodyHolder.sprite = Cp.ItemImage;
            }
            else
            {
                bodyHolder.sprite = null;
            }
            if(Lp != null)
            {
             legHolder.sprite = Lp.ItemImage;
            }
            else
            {
                legHolder.sprite = null;
            }
            if( Weap != null)
            {
             weaponHolder.sprite = Weap.ItemImage;
            }
            else
            {
                weaponHolder.sprite = null;
            }





            iLvl = inventory.Ilvl;
            IlvlTxt.text = iLvl.ToString();
        }
        else
        {
            Helmet = inventory.Helmet;
            Cp = inventory.Body;
            Lp = inventory.Leg;
            Weap = inventory.Weapon;

            iLvl = inventory.Ilvl;
        }
        
    }
}
