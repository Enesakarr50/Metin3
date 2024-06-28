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
        armor[0] = "Ba�lang�� Z�rh�";
        armor[1] = "Ba�lang�� Z�rh�";
        armor[2] = "Ba�lang�� Z�rh�";
        weapon = "Ba�lang�� K�l�c�";
        armorLevels[0] = 1;
        armorLevels[1] = 1;
        armorLevels[2] = 1;
        weaponLevel = 1;

        UpdateUI();
    }

    void UpdateUI()
    {
        armorText.text = "Z�rhlar: " + string.Join(", ", armor);
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
