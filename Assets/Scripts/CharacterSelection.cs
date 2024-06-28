using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void SelectMage()
    {
        PlayerPrefs.SetInt("CharacterClass", (int)CharacterClass.Mage);
        StartGame();
    }

    public void SelectKnight()
    {
        PlayerPrefs.SetInt("CharacterClass", (int)CharacterClass.Knight);
        StartGame();
    }

    public void SelectHunter()
    {
        PlayerPrefs.SetInt("CharacterClass", (int)CharacterClass.Hunter);
        StartGame();
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}