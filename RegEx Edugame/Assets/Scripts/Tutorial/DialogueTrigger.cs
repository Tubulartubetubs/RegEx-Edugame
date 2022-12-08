using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject dialogueHandler;

    private void Start()
    {
        dialogueHandler = GameObject.Find("DialogueHandler");
        //TriggerDialogue();
        StartCoroutine(Trigger());
    }

    private IEnumerator Trigger()
    {
        yield return new WaitForSeconds(.1f);
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        dialogueHandler.GetComponent<DialogueHandler>().StartDialogue(dialogue);
        //foreach(string test in dialogue.sentences)
        //{
        //    Debug.Log(test);
        //}
    }
}
