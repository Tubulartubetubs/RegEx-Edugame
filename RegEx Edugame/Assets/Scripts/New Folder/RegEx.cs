using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RegEx : MonoBehaviour
{
    private TextMeshProUGUI displayText;
    public TextMeshProUGUI summaryText;
    public TextMeshProUGUI chipsUsed;
    public GameObject insertedChips;
    public GameObject waitingChips;
    public GameObject ClearScreen;
    private List<GameObject> chips;
    private List<TextMeshProUGUI> chipTexts;

    //Words to match
    public List<GameObject> highlightWords;
    public List<GameObject> highlightAddresses;

    //Words to skip
    public List<GameObject> skipAddresses;
    
    //public List<Image> pics;

    public List<GameObject> addresses;

    public TextMeshProUGUI totalCrates;

    public TextMeshProUGUI acceptedNum;

    //Scene Handler
    SwitchScenes sceneSwitcher;

    //Number of addresses to move to next scene
    public int allAddresses;

    //turns match collection into list
    List<string> matchStrings;

    public bool goNext;

    private string displayString;
    Color32 redColor = new Color32(219,53,74,141);
    Color32 greenColor = new Color32(53,219,86,141);

    //Numerical value of next scene in build
    public int nextScene;

    public List<string> acceptedStrings;

    Regex rg;

    public int waitingChipCount;
    public int insertedChipCount;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<TextMeshProUGUI>();
        insertedChips = GameObject.Find("ChipInserted");
        waitingChips = GameObject.Find("ChipWaiting");
        chips = new List<GameObject>();
        chipTexts = new List<TextMeshProUGUI>();
        //highlightWords.AddRange(GameObject.FindGameObjectsWithTag("Highlight"));
        addresses.AddRange(GameObject.FindGameObjectsWithTag("Address"));
        //pics.Add(highlightWords[3].transform.parent.gameObject.GetComponentInChildren<Image>());
        totalCrates.text = GameObject.Find("Left side").transform.childCount.ToString();
        acceptedNum.text = "0";
        matchStrings = new List<string>();
        sceneSwitcher = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<SwitchScenes>();
        waitingChipCount = waitingChips.transform.childCount;
        insertedChipCount = insertedChips.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateChips();
        StartCoroutine(Updateupdate());
    }

    IEnumerator Updateupdate()
    {
        yield return new WaitForSeconds(2.0f);
        UpdateChips();
    }

    public void UpdateChips()
    {
        if (insertedChips.transform.childCount > 0)
        {
            foreach (Transform child in insertedChips.transform)
            {
                if (child.gameObject.name != "Invisible Chip" && !chips.Contains(child.gameObject))
                {
                    RectTransform rectTran = child.gameObject.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 125);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 125);
                    RectTransform rectTranText = child.gameObject.transform.Find("Text").GetComponent<RectTransform>();
                    rectTranText.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                    chips.Add(child.gameObject);
                    chipTexts.Add(child.gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>());
                    StringBuilder(chipTexts[chipTexts.Count - 1]);
                }
            }
            insertedChipCount = insertedChips.transform.childCount;
        }
        else
        {
            ResetString();
            DisplayText();
        }

        if (waitingChips.transform.childCount > 0)
        {
            foreach (Transform child in waitingChips.transform)
            {
                if (child.gameObject.name != "Invisible Chip" && !chips.Contains(child.gameObject))
                {
                    RectTransform rectTran = child.gameObject.GetComponent<RectTransform>();
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 231);
                    rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 231);
                    RectTransform rectTranText = child.gameObject.transform.Find("Text").GetComponent<RectTransform>();
                    rectTranText.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
                }
            }
        }

        BuildRegex();
    }

    void StringBuilder(TextMeshProUGUI textMesh)
    {
        displayString += textMesh.text;
        //Debug.Log(displayString);

        DisplayText();
    }

    void BuildRegex()
    {
        try
        {
            rg = new Regex(displayString);
        }
        catch(Exception e) { }
        //Debug.Log("Display String: " + displayString);
        CheckMatches(rg);
    }

    void CheckMatches(Regex rg)
    {
        List<string> texts = new List<string>();

        if (!rg.ToString().Equals(""))
        {
            foreach (GameObject obj in highlightAddresses)
            {
                Match match = rg.Match(obj.GetComponent<TextMeshProUGUI>().text);

                if (match.Success)
                {
                    obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = greenColor;
                    texts.Add(obj.GetComponent<TextMeshProUGUI>().text);
                }
                else
                {
                    obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = redColor;
                }
            }
        }

        //List<string> texts = new List<string>();

        //foreach(GameObject obj in highlightAddresses)
        //{
        //    texts.Add(obj.GetComponent<TextMeshProUGUI>().text);
        //}

        //string wordsToMatch = texts[0];

        //if(texts.Count > 0)
        //{
        //    for(int i=1; i<texts.Count; i++)
        //    {
        //        wordsToMatch = wordsToMatch + " " + texts[i];
        //    }
        //}

        //MatchCollection matches = rg.Matches(wordsToMatch);

        //foreach(Match match in matches)
        //{
        //    matchStrings.Add(match.Value);
        //    //Debug.Log(match.Value);
        //}

        //if(matchStrings.Count > 0)
        //{
        //    //int i = 0;
        //    //foreach(GameObject obj in highlightWords)
        //    //{
        //    //    if (matchStrings.Contains(obj.GetComponent<TextMeshProUGUI>().text))
        //    //    {
        //    //        //obj.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        //    //        highlightAddresses[i].transform.parent.gameObject.GetComponentInChildren<Image>().color = greenColor;
        //    //    }
        //    //    else
        //    //    {
        //    //        //obj.GetComponent<TextMeshProUGUI>().color = Color.white;
        //    //        highlightAddresses[i].transform.parent.gameObject.GetComponentInChildren<Image>().color = redColor;
        //    //    }
        //    //    i++;
        //    //}

        //    //int j = 0;
        //    foreach (GameObject obj in highlightAddresses)
        //    {
        //        foreach(Match match in matches)
        //        {
        //            if (obj.GetComponent<TextMeshProUGUI>().text.Contains(match.Value))
        //            {
        //                obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = greenColor;
        //                break;
        //            }
        //            else
        //            {
        //                obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = redColor;
        //            }
        //        }

        //        //if (obj.GetComponent<TextMeshProUGUI>().text.Contains(matchStrings[j]))
        //        //{
        //        //    obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = greenColor;
        //        //}
        //        //else
        //        //{
        //        //    obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = redColor;
        //        //}
        //        //j++;
        //    }
        //}
        //else
        //{
        //    int i = 0;
        //    foreach(GameObject obj in highlightAddresses)
        //    {
        //        //obj.GetComponent<TextMeshProUGUI>().color = Color.white;
        //        obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = redColor;
        //        i++;
        //    }
        //}

        int matchString = 0;

        if(texts.Count > 0)
        {
            if (!texts[0].Equals(""))
            {
                matchString = texts.Count;
                //Debug.Log("matches: "+ matchString);
                //Debug.Log(texts[0]);
            }
        }
        acceptedNum.text = matchString.ToString();

        if(matchString == allAddresses)
        {
            foreach(string match in texts)
            {
                if (acceptedStrings.Contains(match))
                    goNext = true;
                else
                    goNext = false;

            }
        }

        foreach(GameObject obj in skipAddresses)
        {
            if (obj.GetComponent<TextMeshProUGUI>().color == Color.yellow)
            {
                goNext = false;
            }
        }

        //Debug.Log(wordsToMatch);

        if(goNext)
        {
            //Debug.Log("Switch");
            //sceneSwitcher.SwitchScene(nextScene);
            numChips();
            ClearScreen.SetActive(true);
        }
    }

    void DisplayText()
    {
        displayText.text = displayString;
        summaryText.text = displayString;
    }

    void ResetString()
    {
        displayString = "";
    }

    public void UpdateDisplay()
    {
        chips.Clear();
        chipTexts.Clear();
        matchStrings.Clear();
        ResetString();
        UpdateChips();
    }


    public void nextStage()
    {
        sceneSwitcher.SwitchScene(nextScene);
    }

    public void numChips()
    {
        chipsUsed.text = GameObject.Find("ChipInserted").transform.childCount.ToString();
    }
}
