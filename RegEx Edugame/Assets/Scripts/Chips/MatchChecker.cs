using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MatchChecker : MonoBehaviour
{
    //public string pattern = "Block";
    //public string address = "Block 1 Lot 32 Lavander St. Forbes Village, Brgy.Forbes Makati City";

    public GameObject currChip;
    public ChipDragger chipDragger;
    public ChipManager chipManager;

    public TextMeshProUGUI highlighted;
    public string toBeChecked;

    public Regex pattern;
    public MatchCollection matches;


    // Start is called before the first frame update
    void Start()
    {
        highlighted = GameObject.Find("Highlighting word").GetComponent<TextMeshProUGUI>();
        toBeChecked = highlighted.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.chipDragger != null)
        {
            if (this.chipDragger.isPlaced)
                CheckMatch();
            else
                highlighted.color = Color.white;
        }
    }

    public void CheckMatch()
    {
        matches = pattern.Matches(toBeChecked);

        if (matches[0] != null)
        {
            highlighted.color = Color.yellow;
        }
    }

    public void resetCurrChip()
    {
        this.currChip = null;
        chipDragger = null;
        chipManager = null;
    }

    public void setCurrChip(GameObject currChip)
    {
        this.currChip = currChip;
        chipDragger = currChip.GetComponent<ChipDragger>();
        chipManager = currChip.GetComponent<ChipManager>();
        pattern = new Regex(chipDragger.regex);
        Debug.Log(pattern);
    }
}
