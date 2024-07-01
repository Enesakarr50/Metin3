using UnityEngine.SceneManagement;
using UnityEngine;

public class ClassSelection : MonoBehaviour
{
    public void SelectMage()
    {
        PlayerPrefs.SetInt("ClassEum", (int)Class.Mage);
        StartGame();
    }

    public void SelectKnight()
    {
        PlayerPrefs.SetInt("ClassEum", (int)Class.Knight);
        StartGame();
    }

    public void SelectHunter()
    {
        PlayerPrefs.SetInt("ClassEum", (int)Class.Hunter);
        StartGame();
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}