using UnityEngine;

public class LootItem : MonoBehaviour
{
    public Sprite itemSprite;
    public ItemType itemType;
    public ArmorType armorType;
    public CharacterClass itemClass;
    public int itemLevel;

    public void SetItemProperties(Sprite sprite, ItemType type, ArmorType armorType, CharacterClass itemClass, int level)
    {
        this.itemSprite = sprite;
        this.itemType = type;
        this.armorType = armorType;
        this.itemClass = itemClass;
        this.itemLevel = level;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player.characterClass == itemClass)
            {
                Inventory playerInventory = other.GetComponent<Inventory>();
                switch (armorType)
                {
                    case ArmorType.Helmet:
                        playerInventory.EquipArmor(0, itemSprite, itemLevel);
                        break;
                    case ArmorType.Chestplate:
                        playerInventory.EquipArmor(1, itemSprite, itemLevel);
                        break;
                    case ArmorType.Greaves:
                        playerInventory.EquipArmor(2, itemSprite, itemLevel);
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}
