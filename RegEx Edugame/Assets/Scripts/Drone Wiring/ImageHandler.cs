using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageHandler : MonoBehaviour
{
    public List<GameObject> details;

    public void ShowDetails(int houseNum)
    {
        if (!details[houseNum].activeSelf)
        {
            for (int i = 0; i < details.Count; i++)
            {
                if (i == houseNum)
                    details[i].SetActive(true);
                else
                    details[i].SetActive(false);
            }
        }
        else
            details[houseNum].SetActive(false);
    }
}
