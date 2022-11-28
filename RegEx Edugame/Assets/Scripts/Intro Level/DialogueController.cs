using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    private TextMeshProUGUI dialogueTxt;
    private TextMeshProUGUI titleTxt;
    private SpriteRenderer bgRenderer;
    private SpriteRenderer bgUIBackground;
    private Animator bgAnim;
    private SpriteRenderer bgUIAnim;

    public string[] contentSentences;
    public string[] titles;

    public Sprite[] bgSprites;
    public Sprite[] bgUISprites;

    public float dialogueSpeed;

    public Animator dialogueAnim;
    public RuntimeAnimatorController[] bgAnimator;
    private bool startDialogue = true;
    private bool clickable = true;

    private int index = 0;

    public GameObject sortButton;
    public GameObject detailsButton;
    public GameObject addressButton;
    public GameObject detailsDetails;
    public GameObject addressDetails;

    public AudioClip chatting;
    public AudioClip next;
    AudioSource ChattingSound;
    AudioSource SwippingSound;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTxt = GameObject.Find("Conversation Content").GetComponent<TextMeshProUGUI>();
        titleTxt = GameObject.Find("Conversation Title").GetComponent<TextMeshProUGUI>();
        bgRenderer = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
        bgAnim = GameObject.FindGameObjectWithTag("Background").GetComponent<Animator>();

        //bgUIBackground = GameObject.FindGameObjectWithTag("UIBackground").GetComponent<SpriteRenderer>();
        //bgUIAnim = GameObject.FindGameObjectWithTag("UIBackground").GetComponent<Animator>();

        ChattingSound = this.gameObject.AddComponent<AudioSource>();
        ChattingSound.clip = chatting;
        ChattingSound.loop = true;
        ChattingSound.volume = 0.20f;

        SwippingSound = this.gameObject.AddComponent<AudioSource>();
        SwippingSound.clip = next;
        SwippingSound.volume = 0.10f;
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
                SwippingSound.Play();
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
            ChattingSound.Play();
            foreach (char character in contentSentences[index].ToCharArray())
            {
                dialogueTxt.text += character;

                yield return new WaitForSeconds(dialogueSpeed);
            }
            ChattingSound.Stop();
            dialogueAnim.SetTrigger("Exit");
            yield return new WaitForSeconds(2f);
            ChangeBGAnim(2);
            yield return new WaitForSeconds(1f);
            startDialogue = true;
        }
        else if (index == 3)
        {
            yield return new WaitForSeconds(0.3f);
            ChattingSound.Play();
            foreach (char character in contentSentences[index].ToCharArray())
            {
                dialogueTxt.text += character;
                yield return new WaitForSeconds(dialogueSpeed);
            }
            ChattingSound.Stop();
            dialogueAnim.SetTrigger("Exit");
            yield return new WaitForSeconds(2f);
            ChangeBGAnim(3);
            yield return new WaitForSeconds(3f);
            startDialogue = true;
        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            ChattingSound.Play();
            foreach (char character in contentSentences[index].ToCharArray())
            {
                dialogueTxt.text += character;
                yield return new WaitForSeconds(dialogueSpeed);
            }
            ChattingSound.Stop();
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

    //public void changeUI(int index)
    //{
    //    switch (index)
    //    {
    //        case 0:
    //            bgUIBackground.sprite = bgUISprites[0];
    //            break;

    //        case 1:
    //            bgUIBackground.sprite = bgUISprites[1];
    //            break;

    //        case 2:
    //            bgUIBackground.sprite = bgUISprites[2];
    //            break;

    //        case 3:
    //            bgUIBackground.sprite = bgUISprites[3];
    //            break;

    //        case 4:
    //            bgUIBackground.sprite = bgUISprites[4];
    //            break;
    //    }
    //}

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

    public void Details()
    {
        detailsButton.gameObject.SetActive(true);
        detailsDetails.gameObject.SetActive(true);
    }

    public void Address()
    {
        addressButton.gameObject.SetActive(true);
        addressDetails.gameObject.SetActive(true);
    }
}