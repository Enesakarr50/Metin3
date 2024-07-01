using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public Sprite HelmetHolder,BodyHolder,LegHolder,WeaponHolder;
    public Item Helmet, Body, Leg, Weapon;

}