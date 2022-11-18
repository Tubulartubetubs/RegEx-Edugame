using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public List<TextMeshProUGUI> wireTexts;
    public List<GameObject> ports;

    string displayString;

    TextMeshProUGUI displayTMP;

    public List<GameObject> houses;

    // Start is called before the first frame update
    void Start()
    {
        Regex rg = new Regex("-1");
        Match match = rg.Match("Block 1 Lot 32 Lavander St. Forbes Village, Brgy. Forbes, Makati City");

        Debug.Log(match.Success);


        wireTexts.AddRange(GameObject.Find("Wire Texts").GetComponentsInChildren<TextMeshProUGUI>());
        ports.AddRange(GameObject.FindGameObjectsWithTag("Port"));
        displayString = "";
        displayTMP = GetComponent<TextMeshProUGUI>();
    }

    string StringBuilder()
    {
        foreach(GameObject obj in ports)
        {
            displayString += obj.GetComponent<PlugChecker>().text;
        }

        return displayString;
    }

    void ClearString()
    {
        displayString = "";
    }

    public void UpdateString()
    {
        ClearString();
        string regex = StringBuilder();
        displayTMP.text = regex;
        RegExBuilder(regex);
    }

    void RegExBuilder(string regex)
    {
        Regex rg = new Regex(regex);
        CheckMatches(rg);
    }

    void CheckMatches(Regex rg)
    {
        if(!rg.ToString().Equals(""))
        {
            foreach (GameObject house in houses)
            {
                Match match = rg.Match(house.GetComponent<Address>().address);
                if (match.Success)
                {
                    house.SetActive(true);
                }
                else
                    house.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject house in houses)
            {
                house.SetActive(false);
            }
        }
    }
}
