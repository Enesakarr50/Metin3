using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Ýlk sahneyi yükler. Sahne ismini deðiþtirebilirsiniz.
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // Oyun derleme sýrasýnda çalýþýr. Editor modunda çalýþmaz.
        Application.Quit();

        // Editor modunda çalýþmayý saðlamak için:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
