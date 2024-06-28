using UnityEngine.SceneManagement;
using UnityEngine;

public class ClassSelection : MonoBehaviour
{
    public void SelectMage()
    {
        PlayerPrefs.SetInt("ClassEum", (int)Classes.Mage);
        StartGame();
    }

    public void SelectKnight()
    {
        PlayerPrefs.SetInt("ClassEum", (int)Classes.Knight);
        StartGame();
    }

    public void SelectHunter()
    {
        PlayerPrefs.SetInt("ClassEum", (int)Classes.Hunter);
        StartGame();
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}