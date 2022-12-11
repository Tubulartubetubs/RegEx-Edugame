using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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

    //list of accepted regex strings
    public List<string> acceptedStrings;

    public int nextScene;

    public GameObject indicator;
    Image indicatorImg;

    public Sprite finishedWiring;

    public GameObject droneMoveButton;

    Regex rg;

    public float connectedNum;

    // Start is called before the first frame update
    void Start()
    {
        //Regex test = new Regex("Merano, ");
        //Match testMatch = test.Match("Merano, Athena Classique Phase 1, Imus");
        //Debug.Log(testMatch.Value);

        //ports.AddRange(GameObject.FindGameObjectsWithTag("Port"));

        indicatorImg = indicator.GetComponent<Image>();
        sceneSwitcher = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<SwitchScenes>();
        //string test = "";
        //Regex rg = new Regex("block|");
        //Match match = rg.Match("Block 1 Lot 32 Lavander St. Forbes Village, Brgy. Forbes, Makati City");

        //Debug.Log(match.Success);
        //Debug.Log(match.Value);
        //Debug.Log("".Equals(match.Value));


        wireTexts.AddRange(GameObject.Find("Wire Texts").GetComponentsInChildren<TextMeshProUGUI>());
        //ports.AddRange(GameObject.FindGameObjectsWithTag("Port"));
        displayString = "";
        displayTMP = GetComponent<TextMeshProUGUI>();
    }

    string StringBuilder()
    {
        foreach(GameObject obj in ports)
        {
            displayString += obj.GetComponent<PlugChecker>().text;
        }

        connectedNum = 5;
        foreach(GameObject obj in ports)
        {
            if (!obj.GetComponent<PlugChecker>().isConnected)
            {
                connectedNum--;
            }
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
        Debug.Log(regex);
        displayTMP.text = regex;
        RegExBuilder(regex);
    }

    void RegExBuilder(string regex)
    {
        //Regex rg;
        try
        {
            rg = new Regex(regex);
        }
        catch(Exception e)
        {

        }
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
                Debug.Log(match.Value);
                if (match.Success)
                {
                    house.SetActive(true);
                    if (acceptedStrings.Contains(match.Value))
                    {
                        house.GetComponent<Image>().color = Color.white;
                        staticScreen[i].SetActive(false);
                    }
                    else
                    {
                        staticScreen[i].SetActive(true);
                        house.GetComponent<Image>().color = new Color(1,1,1,connectedNum/5);
                    }
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
            if (house.activeSelf && house.GetComponent<Image>().color == Color.white)
                solvedHouses++;
        }

        if (solvedHouses == completedNum)
        {
            Debug.Log("Move to Next Scene");
            indicatorImg.sprite = finishedWiring;
            droneMoveButton.SetActive(true);
        }
            //sceneSwitcher.SwitchScene(nextScene);
    }

}
