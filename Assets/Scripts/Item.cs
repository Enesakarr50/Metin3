using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Helmet,
    Chestplate,
    Legplate,
    Weapon
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite ItemImage;
    public string ItemName;
    public int ItemLvl;
    public GameObject GameObject;
    public ItemType ItemType;

}