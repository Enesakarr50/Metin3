using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public List<Canvas> npcCanvases; // NPC'nin Canvas'lar�n�n listesi
    public Button closeButton; // Canvas i�indeki buton

    public Dialogue dialogue;
    public DialogueManager dm;

    private int currentPanelIndex = 0; // �u anki panelin indeksi
    private bool playerInRange = false; // Oyuncunun etkile�im alan�nda olup olmad���n� kontrol eden bayrak
    private bool dialogueTriggered = false; // Diyalo�un tetiklenip tetiklenmedi�ini kontrol eden bayrak

    void Start()
    {
        foreach (Canvas canvas in npcCanvases)
        {
            canvas.gameObject.SetActive(false); // Ba�lang��ta t�m Canvas'lar� kapal� yap
        }
        closeButton.onClick.AddListener(NextPanel); // Butona bas�l�nca NextPanel metodunu �a��r
    }

    void Update()
    {
        if (playerInRange && !dialogueTriggered)
        {
            dialogueTriggered = true; // Diyalo�un tetiklendi�ini belirle
        }

        Debug.Log(npcCanvases.Count);
        Debug.Log(currentPanelIndex);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            playerInRange = true; // Oyuncu etkile�im alan�na girdi�inde bayra�� kald�r
            ShowCurrentPanel();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            playerInRange = false; // Oyuncu etkile�im alan�ndan ��kt���nda bayra�� indir
            dialogueTriggered = false; // Oyuncu ayr�ld���nda diyalog tetiklenmemi� olarak ayarla
            HideAllPanels(); // Oyuncu etkile�imden ��k�nca t�m Canvas'lar� kapat
        }
    }

   public void ShowCurrentPanel()
    {
        if (currentPanelIndex < npcCanvases.Count)
        {
            npcCanvases[currentPanelIndex].gameObject.SetActive(true); // �u anki paneli a�
            Debug.Log("Showing panel: " + currentPanelIndex); // Debug mesaj� ekleyin
        }
    }

    void HideAllPanels()
    {
        foreach (Canvas canvas in npcCanvases)
        {
            canvas.gameObject.SetActive(false); // T�m Canvas'lar� kapat
        }
    }

    public void NextPanel()
    {
        if (currentPanelIndex < npcCanvases.Count)
        {
            npcCanvases[currentPanelIndex].gameObject.SetActive(false); // �u anki paneli kapat
            currentPanelIndex++;
            if (currentPanelIndex < npcCanvases.Count)
            {
                npcCanvases[currentPanelIndex].gameObject.SetActive(true); // Bir sonraki paneli a�
                Debug.Log("Showing next panel: " + currentPanelIndex); // Debug mesaj� ekleyin
            }
            else
            {
                Debug.Log("All panels have been shown."); // T�m paneller g�sterildi�inde debug mesaj� ekleyin
            }
        }
        if (currentPanelIndex >= npcCanvases.Count)
        {
            dialogueTriggered = false; // T�m paneller g�sterildikten sonra diyalo�u tamamla
            Debug.Log("Dialogue completed."); // Debug mesaj� ekleyin
        }
    }

    public void CloseCanvas()
    {
        HideAllPanels(); // Butona bas�l�nca t�m Canvas'lar� kapat
        dialogueTriggered = false; // Canvas kapat�ld���nda diyalog tetiklenmemi� olarak ayarla
        Debug.Log("Closing all canvases."); // Debug mesaj� ekleyin
    }
}
