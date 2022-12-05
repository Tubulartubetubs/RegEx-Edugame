using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSheetHandler : MonoBehaviour
{
    /*
     * Main Content
     * 0 = Literals
     * 1 = Digits
     * 2 = Character Sets
     * 3 = Ranges
     * 4 = Quantifiers
     * 5 = Groupings
     * 6 = Alternation
     * 7 = Start/End
     * 8 = Escape
     * 9 = Meta
     * 10 = Wildcard
     * 
     * Meta Content
     * 0 = Meta Parent
     * 1 = alternation
     * 2 = plus
     */

    public List<GameObject> mainContent;
    public List<GameObject> metaContent;
    public AudioClip clickClip;
    AudioSource clickSound;

    private void Start()
    {
        clickSound = this.gameObject.AddComponent<AudioSource>();
        clickSound.clip = clickClip;
        clickSound.volume = 0.10f;
    }

    public void ChangeMainContent(int content)
    {
        for(int i = 0; i<mainContent.Count; i++)
        {
            mainContent[i].SetActive(false);
        }
        mainContent[content].SetActive(true);
        clickSound.Play();
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
