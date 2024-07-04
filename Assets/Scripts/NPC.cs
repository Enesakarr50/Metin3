using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Canvas npcCanvas; // NPC'nin Canvas'ý
    public Button closeButton; // Canvas içindeki buton

    void Start()
    {
        npcCanvas.gameObject.SetActive(false); // Baþlangýçta Canvas kapalý
        closeButton.onClick.AddListener(CloseCanvas); // Butona basýlýnca CloseCanvas metodunu çaðýr
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("sdfsdfs");
            npcCanvas.gameObject.SetActive(true); // Oyuncu etkileþime geçince Canvas'ý aç
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            npcCanvas.gameObject.SetActive(false); // Oyuncu etkileþimden çýkýnca Canvas'ý kapat
        }
    }
   

    public void CloseCanvas()
    {
        npcCanvas.gameObject.SetActive(false); // Butona basýlýnca Canvas'ý kapat
    }
}
