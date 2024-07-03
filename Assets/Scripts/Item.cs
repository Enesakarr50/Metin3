using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Helmet,
    Chestplate,
    Legplate,
    Weapon
}
public enum Class
{
    Mage,
    Knight,
    Hunter
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite ItemImage;
    public string ItemName;
    public int ItemLvl;
    public GameObject GameObject;
    public ItemType ItemType;
    public Class Class;

}