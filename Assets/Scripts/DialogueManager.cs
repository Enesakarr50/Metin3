using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public bool isOpen;

    private Queue<string> sentences;

    public Dialogue d;

    public NPC NPC;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>(d.sentences);
    }
    private void Update()
    {
        d = NPC.GetComponent<NPC>().dialogue;
        nameText.text = d.name;
        Debug.Log(nameText.text);
    }

    public void StartDialogue()
    {
        
        animator.SetBool("IsOpen", isOpen);


        foreach (string sentence in d.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentencie)
    {
        dialogueText.text = "";
        foreach (char letter in sentencie.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
