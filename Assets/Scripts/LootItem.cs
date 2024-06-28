using UnityEngine;

public class LootItem : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player.characterClass == itemClass)
            {
                Inventory playerInventory = other.GetComponent<Inventory>();
                if (itemType == ItemType.Weapon)
                {
                    playerInventory.EquipWeapon(itemName + " Lv." + itemLevel, itemLevel);
                }
                else if (itemType == ItemType.Armor)
                {
                    playerInventory.EquipArmor(0, itemName + " Lv." + itemLevel, itemLevel); // Zýrh slotunu uygun þekilde ayarlayýn
                }
                Destroy(gameObject);
            }
        }
    }
}
