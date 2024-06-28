using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] armorImages; // Kafalýk, Göðüslük, Dizlik
    public Image weaponImage;

    private Sprite[] armorSprites = new Sprite[3];
    private Sprite weaponSprite;
    private int[] armorLevels = new int[3];
    private int weaponLevel;

    void Start()
    {
        // Baþlangýç eþyalarý
        armorSprites[0] = Resources.Load<Sprite>("Armors/Items/Icon30_01");
        armorSprites[1] = Resources.Load<Sprite>("Armors/Items/Icon30_01");
        armorSprites[2] = Resources.Load<Sprite>("Armors/Items/Icon30_01");
        weaponSprite = Resources.Load<Sprite>("Armors/Items/Icon30_01");
        armorLevels[0] = 1;
        armorLevels[1] = 1;
        armorLevels[2] = 1;
        weaponLevel = 1;

        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < armorImages.Length; i++)
        {
            armorImages[i].sprite = armorSprites[i];
        }
        weaponImage.sprite = weaponSprite;
    }

    public void EquipArmor(int slot, Sprite newArmorSprite, int level)
    {
        armorSprites[slot] = newArmorSprite;
        armorLevels[slot] = level;
        UpdateUI();
    }

    public void EquipWeapon(Sprite newWeaponSprite, int level)
    {
        weaponSprite = newWeaponSprite;
        weaponLevel = level;
        UpdateUI();
    }

    public int GetHighestItemLevel()
    {
        return Mathf.Max(weaponLevel, armorLevels.Max());
    }
}
