using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage; // Sa�l�k bar�n�n dolu k�sm�
    private int maxHealth;

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        fillImage.fillAmount = 1f; // Sa�l�k bar�n� tamamen doldur
    }

    public void SetHealth(int health)
    {
        fillImage.fillAmount = (float)health / maxHealth; // Sa�l�k bar�n�n doluluk oran�n� g�ncelle
    }
}
