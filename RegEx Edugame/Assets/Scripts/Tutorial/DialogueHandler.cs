using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public Queue<string> sentences;
    public float dialogueSpeed;

    public TextMeshProUGUI dialogueText;

    public List<GameObject> scenes;

    public List<GameObject> buttons;

    public GameObject indicator;

    public GameObject drone;

    public List<Image> ports;

    public GameObject noise;

    public GameObject office;

    int sceneCounter = 0;

    Image chipBag;
    Image matchBook;
    Image cheatSheet;

    //public List<GameObject> Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        chipBag = buttons[0].GetComponent<Image>();
        matchBook = buttons[1].GetComponent<Image>();
        cheatSheet = buttons[2].GetComponent<Image>();

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        sceneCounter = 0;
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

        switch (sceneCounter)
        {
            case 1: chipBag.color = Color.green;
                    matchBook.color = Color.white;
                    cheatSheet.color = Color.white;
                break;
            case 3: chipBag.color = Color.white;
                    matchBook.color = Color.green;
                    cheatSheet.color = Color.white;
                break;
            case 4: chipBag.color = Color.white;
                    matchBook.color = Color.white;
                    cheatSheet.color = Color.green;
                break;
            case 5: scenes[0].SetActive(false);
                    scenes[1].SetActive(true);
                break;
            case 6:
                    drone.SetActive(true);
                    ports[0].color = Color.green;
                    ports[1].color = Color.green;
                    ports[2].color = Color.green;
                    ports[3].color = Color.green;
                    ports[4].color = Color.green;
                break;
            case 7:
                    ports[0].color = Color.white;
                    ports[1].color = Color.white;
                    ports[2].color = Color.white;
                    ports[3].color = Color.white;
                    ports[4].color = Color.white;
                    indicator.SetActive(true);
                break;
            case 8: 
                    drone.SetActive(false);
                    noise.SetActive(true);
                break;
            case 13:
                    noise.SetActive(false);
                    office.SetActive(true);
                break;
        }

        sceneCounter++;
    }

    void EndDialogue()
    {
        Debug.Log("Sentence End");
    }
}
