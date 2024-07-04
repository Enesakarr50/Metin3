using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage; // Saðlýk barýnýn dolu kýsmý
    private int maxHealth;

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        fillImage.fillAmount = 1f; // Saðlýk barýný tamamen doldur
    }

    public void SetHealth(int health)
    {
        fillImage.fillAmount = (float)health / maxHealth; // Saðlýk barýnýn doluluk oranýný güncelle
    }
}
