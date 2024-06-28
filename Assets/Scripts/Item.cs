using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor
}

public class Item : MonoBehaviour
{
    public string itemName;
    public ItemType itemType;
    public CharacterClass itemClass;
    public int itemLevel;

    public void SetItemProperties(string name, ItemType type, CharacterClass itemClass, int level)
    {
        this.itemName = name;
        this.itemType = type;
        this.itemClass = itemClass;
        this.itemLevel = level;
    }
}