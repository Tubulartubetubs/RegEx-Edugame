using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public List<TextMeshProUGUI> wireTexts;
    public List<GameObject> ports;

    string displayString;

    TextMeshProUGUI displayTMP;

    // Start is called before the first frame update
    void Start()
    {
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
        displayTMP.text = StringBuilder();
    }
}
