using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public List<TextMeshProUGUI> wireTexts;
    public List<GameObject> ports;

    public List<GameObject> staticScreen;

    string displayString;

    TextMeshProUGUI displayTMP;

    public List<GameObject> houses;

    public int completedNum;

    SwitchScenes sceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {

        sceneSwitcher = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<SwitchScenes>();
        //string test = "";
        Regex rg = new Regex("block|");
        Match match = rg.Match("Block 1 Lot 32 Lavander St. Forbes Village, Brgy. Forbes, Makati City");

        Debug.Log(match.Success);
        Debug.Log(match.Value);
        Debug.Log("".Equals(match.Value));


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
        int i = 0;
        if(!rg.ToString().Equals(""))
        {
            foreach (GameObject house in houses)
            {
                Match match = rg.Match(house.GetComponent<Address>().address);
                if (match.Success)
                {
                    if (!"".Equals(match.Value))
                        house.SetActive(true);
                    else
                        staticScreen[i].SetActive(true);
                }
                else
                {
                    house.SetActive(false);
                    staticScreen[i].SetActive(false);
                }

                i++;
            }
        }
        else
        {
            foreach (GameObject house in houses)
            {
                house.SetActive(false);
                staticScreen[i].SetActive(false);
                i++;
            }
        }

        int solvedHouses=0;

        foreach(GameObject house in houses)
        {
            if (house.activeSelf)
                solvedHouses++;
        }

        if (solvedHouses == completedNum)
            sceneSwitcher.SwitchScene(5);
    }
}
