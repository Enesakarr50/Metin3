using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public ItemType itemType;
    public ArmorType armorType;
    public CharacterClass itemClass;
    public int itemLevel;

    public void SetItemProperties(string name, ItemType type, ArmorType armorType, CharacterClass itemClass, int level, string spritePath)
    {
        this.itemName = name;
        this.itemType = type;
        this.armorType = armorType;
        this.itemClass = itemClass;
        this.itemLevel = level;

        // Burada sprite yükleme veya diðer ayarlamalarý yapabilirsiniz
    }
}
