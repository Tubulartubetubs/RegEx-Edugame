using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getText : MonoBehaviour
{
    private TextMeshProUGUI summaryText;
    public RegEx displayText;
    // Start is called before the first frame update
    void Start()
    {
        summaryText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        summaryText.text = displayText.GetText();
    }
}
