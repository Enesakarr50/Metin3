using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Canvas npcCanvas; // NPC'nin Canvas'�
    public Button closeButton; // Canvas i�indeki buton

    void Start()
    {
        npcCanvas.gameObject.SetActive(false); // Ba�lang��ta Canvas kapal�
        closeButton.onClick.AddListener(CloseCanvas); // Butona bas�l�nca CloseCanvas metodunu �a��r
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("sdfsdfs");
            npcCanvas.gameObject.SetActive(true); // Oyuncu etkile�ime ge�ince Canvas'� a�
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            npcCanvas.gameObject.SetActive(false); // Oyuncu etkile�imden ��k�nca Canvas'� kapat
        }
    }
   

    public void CloseCanvas()
    {
        npcCanvas.gameObject.SetActive(false); // Butona bas�l�nca Canvas'� kapat
    }
}
