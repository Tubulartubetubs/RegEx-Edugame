using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public Queue<string> sentences;
    public float dialogueSpeed;

    public TextMeshProUGUI dialogueText;

    //public List<GameObject> Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Debug.Log(sentences.Dequeue());
        dialogueText.text = sentences.Dequeue();
    }

    void EndDialogue()
    {
        Debug.Log("Sentence End");
    }
}
