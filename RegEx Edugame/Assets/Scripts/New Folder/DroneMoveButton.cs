using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMoveButton : MonoBehaviour
{
    public GameObject chipsBag;
    public GameObject bg;

    public void showChipsBag()
    {
        if (chipsBag.activeSelf == true) {
            chipsBag.SetActive(false);
            bg.SetActive(false);
        }

        else if (chipsBag.activeSelf == false)
        {
            chipsBag.SetActive(true);
            bg.SetActive(true);
        }
            
    }
}
