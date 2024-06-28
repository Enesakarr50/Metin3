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
        mageItems.Add(CreateItem("Mage Staff", ItemType.Weapon, ArmorType.Unspecified, CharacterClass.Mage, 1, "Sprites/MageStaff"));
        mageItems.Add(CreateItem("Mage Robe", ItemType.Armor, ArmorType.Helmet, CharacterClass.Mage, 1, "Sprites/MageHelmet"));
        mageItems.Add(CreateItem("Mage Robe", ItemType.Armor, ArmorType.Chestplate, CharacterClass.Mage, 1, "Sprites/MageChestplate"));
        mageItems.Add(CreateItem("Mage Robe", ItemType.Armor, ArmorType.Greaves, CharacterClass.Mage, 1, "Sprites/MageGreaves"));

        // Knight items
        knightItems.Add(CreateItem("Knight Sword", ItemType.Weapon, ArmorType.Unspecified, CharacterClass.Knight, 1, "Sprites/KnightSword"));
        knightItems.Add(CreateItem("Knight Armor", ItemType.Armor, ArmorType.Helmet, CharacterClass.Knight, 1, "Sprites/KnightHelmet"));
        knightItems.Add(CreateItem("Knight Armor", ItemType.Armor, ArmorType.Chestplate, CharacterClass.Knight, 1, "Sprites/KnightChestplate"));
        knightItems.Add(CreateItem("Knight Armor", ItemType.Armor, ArmorType.Greaves, CharacterClass.Knight, 1, "Sprites/KnightGreaves"));

        // Hunter items
        hunterItems.Add(CreateItem("Hunter Bow", ItemType.Weapon, ArmorType.Unspecified, CharacterClass.Hunter, 1, "Sprites/HunterBow"));
        hunterItems.Add(CreateItem("Hunter Cloak", ItemType.Armor, ArmorType.Helmet, CharacterClass.Hunter, 1, "Sprites/HunterHelmet"));
        hunterItems.Add(CreateItem("Hunter Cloak", ItemType.Armor, ArmorType.Chestplate, CharacterClass.Hunter, 1, "Sprites/HunterChestplate"));
        hunterItems.Add(CreateItem("Hunter Cloak", ItemType.Armor, ArmorType.Greaves, CharacterClass.Hunter, 1, "Sprites/HunterGreaves"));
    }

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
