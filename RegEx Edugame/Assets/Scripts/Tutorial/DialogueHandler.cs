using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public List<string> dialogue;
    public float dialogueSpeed;

    public List<GameObject> Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in GameObject.FindGameObjectWithTag("TutorialParent").transform)
        {
            Tutorial.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
