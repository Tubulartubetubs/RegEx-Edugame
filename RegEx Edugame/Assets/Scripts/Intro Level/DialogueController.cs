using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    private TextMeshProUGUI dialogueTxt;
    private TextMeshProUGUI titleTxt;
    private SpriteRenderer bgRenderer;
    private Animator bgAnim;

    public string[] contentSentences;
    public string[] titles;

    public Sprite[] bgSprites;

    public float dialogueSpeed;

    public Animator dialogueAnim;
    public RuntimeAnimatorController[] bgAnimator;
    private bool startDialogue = true;
    private bool clickable = true;

    private int index = 0;

    public GameObject sortButton;

    public AudioClip chatting;
    public AudioClip next;
    AudioSource audioSource;
    AudioSource audioSource2;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTxt = GameObject.Find("Conversation Content").GetComponent<TextMeshProUGUI>();
        titleTxt = GameObject.Find("Conversation Title").GetComponent<TextMeshProUGUI>();
        bgRenderer = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
        bgAnim = GameObject.FindGameObjectWithTag("Background").GetComponent<Animator>();
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = chatting;
        audioSource.loop = true;
        audioSource.volume = 0.03f;

        audioSource2 = this.gameObject.AddComponent<AudioSource>();
        audioSource2.clip = next;
        audioSource2.volume = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) && clickable) || startDialogue)
        {
            if (startDialogue)
            {
                dialogueTxt.text = "";
                dialogueAnim.SetTrigger("Enter");
                startDialogue = false;
                NextSentence();
            }
            else
            {
                audioSource2.Play();
                NextSentence();
            }
        }
    }

    void NextSentence()
    {
        dialogueTxt.text = "";
        if (index < contentSentences.Length)
        {
            StartCoroutine(WriteSentence());
        }
        else
        {
            dialogueAnim.SetTrigger("Exit");
            Invoke("Sort", 1); //delay to the sort button
            //sortButton.gameObject.SetActive(true);
        }
    }

    IEnumerator WriteSentence()
    {
        clickable = false;
        if (index == 2)
        {
            yield return new WaitForSeconds(0.3f);
            bgRenderer.sprite = bgSprites[1];
            audioSource.Play();
            foreach (char character in contentSentences[index].ToCharArray())
            {
                dialogueTxt.text += character;

                yield return new WaitForSeconds(dialogueSpeed);
            }
            audioSource.Stop();
            dialogueAnim.SetTrigger("Exit");
            yield return new WaitForSeconds(2f);
            ChangeBGAnim(2);
            yield return new WaitForSeconds(1f);
            startDialogue = true;
        }
        else if (index == 3)
        {
            yield return new WaitForSeconds(0.3f);
            audioSource.Play();
            foreach (char character in contentSentences[index].ToCharArray())
            {
                dialogueTxt.text += character;
                yield return new WaitForSeconds(dialogueSpeed);
            }
            audioSource.Stop();
            dialogueAnim.SetTrigger("Exit");
            yield return new WaitForSeconds(2f);
            ChangeBGAnim(3);
            yield return new WaitForSeconds(3f);
            startDialogue = true;
        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            audioSource.Play();
            foreach (char character in contentSentences[index].ToCharArray())
            {
                dialogueTxt.text += character;
                yield return new WaitForSeconds(dialogueSpeed);
            }
            audioSource.Stop();
        }
        index++;
        clickable = true;
    }

    public void changeBG(int index)
    {
        switch (index)
        {
            case 2: 
                bgRenderer.sprite = bgSprites[1];
                break;
        }
    }
    
    public void ChangeBGAnim(int index)
    {
        switch (index)
        {
            case 2: 
                bgAnim.runtimeAnimatorController = bgAnimator[0];
                bgAnim.enabled = true;
                bgAnim.SetTrigger("Enter");
                break;
            case 3:
                bgAnim.runtimeAnimatorController = bgAnimator[1];
                bgAnim.enabled = true;
                bgAnim.SetTrigger("Enter");
                break;
        }
    }

    public void Sort()
    {
        sortButton.gameObject.SetActive(true);
    }
}