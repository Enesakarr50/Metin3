using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // �lk sahneyi y�kler. Sahne ismini de�i�tirebilirsiniz.
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // Oyun derleme s�ras�nda �al���r. Editor modunda �al��maz.
        Application.Quit();

        // Editor modunda �al��may� sa�lamak i�in:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
