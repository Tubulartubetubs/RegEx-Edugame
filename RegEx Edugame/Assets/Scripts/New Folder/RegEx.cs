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

    private string displayString;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<TextMeshProUGUI>();
        insertedChips = GameObject.Find("ChipInserted");
        chips = new List<GameObject>();
        chipTexts = new List<TextMeshProUGUI>();
        highlightWords.AddRange(GameObject.FindGameObjectsWithTag("Highlight"));
    }

    // Update is called once per frame
    void Update()
    {
        //if (insertedChips.transform.childCount > 0)
        //{
        //    UpdateChips();
        //}
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

        if (matches.Count > 0)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                for (int j = 0; j < highlightWords.Count; j++)
                {
                    if (matches[i].Value.Equals(highlightWords[j].GetComponent<TextMeshProUGUI>().text))
                    {
                        highlightWords[j].GetComponent<TextMeshProUGUI>().color = Color.yellow;
                    }
                    else
                        highlightWords[j].GetComponent<TextMeshProUGUI>().color = Color.white;
                }
            }
        }
        else
        {
            foreach(GameObject obj in highlightWords)
            {
                obj.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
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
        ResetString();
        UpdateChips();
    }
}
