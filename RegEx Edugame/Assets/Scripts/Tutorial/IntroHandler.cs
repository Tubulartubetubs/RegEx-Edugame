using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroHandler : MonoBehaviour
{
    Queue<string> intro;

    public TextMeshProUGUI introText;

    public SwitchScenes sceneHandler;

    // Start is called before the first frame update
    void Start()
    {
        intro = new Queue<string>();
    }

    public void StartIntro(Introduction introduction)
    {
        intro.Clear();

        foreach(string sentence in introduction.introduction)
        {
            intro.Enqueue(sentence);
        }

        InvokeRepeating("DisplayIntro", .1f, 5f);
    }

    public void DisplayIntro()
    {
        if(intro.Count == 0)
        {
            EndDialogue();
            return;
        }

        introText.text = intro.Dequeue();
    }

    public void EndDialogue()
    {
        CancelInvoke();
        sceneHandler.SwitchScene(1);
    }
}
