using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject lootPrefab;
    public Inventory playerInventory;
    public ItemPool itemPool;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (Random.value < 0.5f)
        {
            DropLoot();
        }
        Destroy(gameObject);
    }

    void DropLoot()
    {
        CharacterClass playerClass = playerInventory.GetComponent<Player>().characterClass;
        int highestLevel = playerInventory.GetHighestItemLevel();
        Item randomItem = itemPool.GetRandomItem(playerClass, highestLevel + 1);

        if (randomItem != null)
        {
            GameObject loot = Instantiate(lootPrefab, transform.position, Quaternion.identity);
            LootItem lootItem = loot.GetComponent<LootItem>();
            lootItem.SetItemProperties(randomItem.itemName, randomItem.itemType, randomItem.itemClass, randomItem.itemLevel);
        }
    }
}