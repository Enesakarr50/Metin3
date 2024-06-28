using UnityEngine;
using System.Collections.Generic;

public class ItemPool : MonoBehaviour
{
    public List<Item> mageItems = new List<Item>();
    public List<Item> knightItems = new List<Item>();
    public List<Item> hunterItems = new List<Item>();

    void Start()
    {
        // Mage items
        mageItems.Add(CreateItem("Mage Staff", ItemType.Weapon, CharacterClass.Mage, 5));
        mageItems.Add(CreateItem("Mage Robe", ItemType.Armor, CharacterClass.Mage, 6));

        // Knight items
        knightItems.Add(CreateItem("Knight Sword", ItemType.Weapon, CharacterClass.Knight, 1));
        knightItems.Add(CreateItem("Knight Armor", ItemType.Armor, CharacterClass.Knight, 1));

        // Hunter items
        hunterItems.Add(CreateItem("Hunter Bow", ItemType.Weapon, CharacterClass.Hunter, 1));
        hunterItems.Add(CreateItem("Hunter Cloak", ItemType.Armor, CharacterClass.Hunter, 1));
    }

    Item CreateItem(string name, ItemType type, CharacterClass itemClass, int level)
    {
        GameObject itemObject = new GameObject(name);
        Item item = itemObject.AddComponent<Item>();
        item.SetItemProperties(name, type, itemClass, level);
        return item;
    }

    public Item GetRandomItem(CharacterClass characterClass, int minLevel)
    {
        List<Item> items = new List<Item>();

        switch (characterClass)
        {
            case CharacterClass.Mage:
                items = mageItems;
                break;
            case CharacterClass.Knight:
                items = knightItems;
                break;
            case CharacterClass.Hunter:
                items = hunterItems;
                break;
        }

        List<Item> validItems = items.FindAll(item => item.itemLevel >= minLevel);

        if (validItems.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, validItems.Count);
        return validItems[randomIndex];
    }
}