using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMoveButton : MonoBehaviour
{
    public GameObject chipsBag;
    public GameObject chipsBagBG;

    public GameObject selectCrate;
    public GameObject crateBG;

    public void showChipsBag()
    {
        if (chipsBag.activeSelf == true) {
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
        }

        else if (chipsBag.activeSelf == false)
        {
            chipsBag.SetActive(true);
            chipsBagBG.SetActive(true);
        }       
    }

    public void showSelectCrate()
    {
        if (selectCrate.activeSelf == true)
        {
            selectCrate.SetActive(false);
            crateBG.SetActive(false);
        }

        else if (selectCrate.activeSelf == false)
        {
            selectCrate.SetActive(true);
            crateBG.SetActive(true);
        }
    }
}
