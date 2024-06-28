using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public Image HelmetHolder,BodyHolder,LegHolder,WeaponHolder;
    public Image Helmet, Body, Leg, Weapon;

}