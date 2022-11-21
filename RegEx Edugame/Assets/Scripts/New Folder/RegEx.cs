using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegEx : MonoBehaviour
{
    private TextMeshProUGUI displayText;
    private GameObject insertedChips;
    private List<GameObject> chips;
    private List<TextMeshProUGUI> chipTexts;

    public List<GameObject> highlightWords;

    public List<Image> pics;

    public List<GameObject> addresses;

    public TextMeshProUGUI totalCrates;

    public TextMeshProUGUI acceptedNum;

    //Scene Handler
    SwitchScenes sceneSwitcher;

    //Number of addresses to move to next scene
    public int allAddresses;

    //turns match collection into list
    List<string> matchStrings;

    private string displayString;
    Color32 redColor = new Color32(219,53,74,141);
    Color32 greenColor = new Color32(53,219,86,141);

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<TextMeshProUGUI>();
        insertedChips = GameObject.Find("ChipInserted");
        chips = new List<GameObject>();
        chipTexts = new List<TextMeshProUGUI>();
        //highlightWords.AddRange(GameObject.FindGameObjectsWithTag("Highlight"));
        addresses.AddRange(GameObject.FindGameObjectsWithTag("Address"));
        pics.Add(highlightWords[3].transform.parent.gameObject.GetComponentInChildren<Image>());
        totalCrates.text = GameObject.Find("Left side").transform.childCount.ToString();
        acceptedNum.text = "0";
        matchStrings = new List<string>();
        sceneSwitcher = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<SwitchScenes>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateChips()
    {
        foreach (Transform child in insertedChips.transform)
        {
            if (child.gameObject.name != "Invisible Chip" && !chips.Contains(child.gameObject))
            {
                chips.Add(child.gameObject);
                chipTexts.Add(child.gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>());
                StringBuilder(chipTexts[chipTexts.Count - 1]);
            }
        }

        BuildRegex();
    }

    void StringBuilder(TextMeshProUGUI textMesh)
    {
        displayString += textMesh.text;

        DisplayText();
    }

    void BuildRegex()
    {
        Regex rg = new Regex(displayString);
        Debug.Log("Display String: " + displayString);
        CheckMatches(rg);
    }

    void CheckMatches(Regex rg)
    {
        List<string> texts = new List<string>();

        foreach(GameObject obj in highlightWords)
        {
            texts.Add(obj.GetComponent<TextMeshProUGUI>().text);
        }

        string wordsToMatch = texts[0];

        if(texts.Count > 0)
        {
            for(int i=1; i<texts.Count; i++)
            {
                wordsToMatch = wordsToMatch + " " + texts[i];
            }
        }

        MatchCollection matches = rg.Matches(wordsToMatch);

        foreach(Match match in matches)
        {
            matchStrings.Add(match.Value);
        }

        if(matchStrings.Count > 0)
        {
            foreach(GameObject obj in highlightWords)
            {
                if (matchStrings.Contains(obj.GetComponent<TextMeshProUGUI>().text))
                {
                    obj.GetComponent<TextMeshProUGUI>().color = Color.yellow;
                    if (obj.name.Equals("Highlighting Address"))
                        obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = greenColor;
                }
                else
                {
                    obj.GetComponent<TextMeshProUGUI>().color = Color.white;
                    if (obj.name.Equals("Highlighting Address"))
                        obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = redColor;
                }
            }
        }
        else
        {
            foreach(GameObject obj in highlightWords)
            {
                obj.GetComponent<TextMeshProUGUI>().color = Color.white;
                if (obj.name.Equals("Highlighting Address"))
                    obj.transform.parent.gameObject.GetComponentInChildren<Image>().color = redColor;
            }
        }

        int matchString = (matches.Count/2);
        acceptedNum.text = matchString.ToString();

        if(matchString == allAddresses)
        {
            Debug.Log("Switch");
            sceneSwitcher.SwitchScene(4);
        }
    }

    void DisplayText()
    {
        displayText.text = displayString;
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
}