using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI weaponText;

    private string[] armor = new string[3];
    private string weapon;
    private int[] armorLevels = new int[3];
    private int weaponLevel;

    void Start()
    {
        armor[0] = "Baþlangýç Zýrhý";
        armor[1] = "Baþlangýç Zýrhý";
        armor[2] = "Baþlangýç Zýrhý";
        weapon = "Baþlangýç Kýlýcý";
        armorLevels[0] = 1;
        armorLevels[1] = 1;
        armorLevels[2] = 1;
        weaponLevel = 1;

        UpdateUI();
    }

    void UpdateUI()
    {
        armorText.text = "Zýrhlar: " + string.Join(", ", armor);
        weaponText.text = "Silah: " + weapon;
    }

    public void EquipArmor(int slot, string newArmor, int level)
    {
        armor[slot] = newArmor;
        armorLevels[slot] = level;
        UpdateUI();
    }

    public void EquipWeapon(string newWeapon, int level)
    {
        weapon = newWeapon;
        weaponLevel = level;
        UpdateUI();
    }

    public int GetHighestItemLevel()
    {
        return Mathf.Max(weaponLevel, armorLevels.Max());
    }
}
