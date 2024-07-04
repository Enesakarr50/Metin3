using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public List<Canvas> npcCanvases; // NPC'nin Canvas'larýnýn listesi
    public Button closeButton; // Canvas içindeki buton

    public Dialogue dialogue;
    public DialogueManager dm;

    private int currentPanelIndex = 0; // Þu anki panelin indeksi
    private bool playerInRange = false; // Oyuncunun etkileþim alanýnda olup olmadýðýný kontrol eden bayrak
    private bool dialogueTriggered = false; // Diyaloðun tetiklenip tetiklenmediðini kontrol eden bayrak

    void Start()
    {
        foreach (Canvas canvas in npcCanvases)
        {
            canvas.gameObject.SetActive(false); // Baþlangýçta tüm Canvas'larý kapalý yap
        }
        closeButton.onClick.AddListener(NextPanel); // Butona basýlýnca NextPanel metodunu çaðýr
    }

    void Update()
    {
        if (playerInRange && !dialogueTriggered)
        {
            dialogueTriggered = true; // Diyaloðun tetiklendiðini belirle
        }

        Debug.Log(npcCanvases.Count);
        Debug.Log(currentPanelIndex);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            playerInRange = true; // Oyuncu etkileþim alanýna girdiðinde bayraðý kaldýr
            ShowCurrentPanel();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            playerInRange = false; // Oyuncu etkileþim alanýndan çýktýðýnda bayraðý indir
            dialogueTriggered = false; // Oyuncu ayrýldýðýnda diyalog tetiklenmemiþ olarak ayarla
            HideAllPanels(); // Oyuncu etkileþimden çýkýnca tüm Canvas'larý kapat
        }
    }

   public void ShowCurrentPanel()
    {
        if (currentPanelIndex < npcCanvases.Count)
        {
            npcCanvases[currentPanelIndex].gameObject.SetActive(true); // Þu anki paneli aç
            Debug.Log("Showing panel: " + currentPanelIndex); // Debug mesajý ekleyin
        }
    }

    void HideAllPanels()
    {
        foreach (Canvas canvas in npcCanvases)
        {
            canvas.gameObject.SetActive(false); // Tüm Canvas'larý kapat
        }
    }

    public void NextPanel()
    {
        if (currentPanelIndex < npcCanvases.Count)
        {
            npcCanvases[currentPanelIndex].gameObject.SetActive(false); // Þu anki paneli kapat
            currentPanelIndex++;
            if (currentPanelIndex < npcCanvases.Count)
            {
                npcCanvases[currentPanelIndex].gameObject.SetActive(true); // Bir sonraki paneli aç
                Debug.Log("Showing next panel: " + currentPanelIndex); // Debug mesajý ekleyin
            }
            else
            {
                Debug.Log("All panels have been shown."); // Tüm paneller gösterildiðinde debug mesajý ekleyin
            }
        }
        if (currentPanelIndex >= npcCanvases.Count)
        {
            dialogueTriggered = false; // Tüm paneller gösterildikten sonra diyaloðu tamamla
            Debug.Log("Dialogue completed."); // Debug mesajý ekleyin
        }
    }

    public void CloseCanvas()
    {
        HideAllPanels(); // Butona basýlýnca tüm Canvas'larý kapat
        dialogueTriggered = false; // Canvas kapatýldýðýnda diyalog tetiklenmemiþ olarak ayarla
        Debug.Log("Closing all canvases."); // Debug mesajý ekleyin
    }
}
