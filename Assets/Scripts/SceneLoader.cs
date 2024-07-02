using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void Dugeon1(string sceneName)
    {
        SceneManager.LoadScene("Dungeon1");
    }

    public void Dungeon2(string sceneName)
    {
        SceneManager.LoadScene("Dungeon2");
    }
}
