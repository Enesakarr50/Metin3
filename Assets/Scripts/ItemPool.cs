using UnityEngine;
using System.Collections.Generic;

public class ItemPool : MonoBehaviour
{
    public List<Item> mageItems = new List<Item>();
    public List<Item> knightItems = new List<Item>();
    public List<Item> hunterItems = new List<Item>();


    Item CreateItem(string name, ItemType type, ArmorType armorType, CharacterClass itemClass, int level, string spritePath)
    {
        GameObject itemObject = new GameObject(name);
        Item item = itemObject.AddComponent<Item>();
        item.SetItemProperties(name, type, armorType, itemClass, level, spritePath); // SetItemProperties metodunun doðru parametrelerle çaðrýldýðýndan emin olun
        SpriteRenderer spriteRenderer = itemObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(spritePath);
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
