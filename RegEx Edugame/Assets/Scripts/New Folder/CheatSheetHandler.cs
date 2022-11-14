using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSheetHandler : MonoBehaviour
{
    /*
     * Main Content
     * 0 = literals
     * 1 = meta
     * 
     * Meta Content
     * 0 = Meta Parent
     * 1 = alternation
     * 2 = plus
     */

    public List<GameObject> mainContent;
    public List<GameObject> metaContent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMainContent(int content)
    {
        switch (content)
        {
            case 0: 
                mainContent[0].SetActive(true);
                break;
            case 1:
                mainContent[1].SetActive(true);
                metaContent[0].SetActive(true);
                metaContent[1].SetActive(false);
                metaContent[2].SetActive(false);
                break;
        }

        for(int i=0; i<mainContent.Count; i++)
        {
            if (i != content)
            {
                mainContent[i].SetActive(false);
            }
        }
    }

    public void ChangeMetaContent(int content)
    {
        metaContent[content].SetActive(true);

        for(int i=0; i<metaContent.Count; i++)
        {
            if (i != content)
            {
                metaContent[i].SetActive(false);
            }
        }
    }
}
