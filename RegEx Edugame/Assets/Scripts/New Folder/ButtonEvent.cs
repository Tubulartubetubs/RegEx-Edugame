using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    //public GameObject details1;
    //public GameObject address1;
    //public GameObject next1;
    //public GameObject prev1;

    //public GameObject details2;
    //public GameObject address2;
    //public GameObject next2;
    //public GameObject prev2;

    //public GameObject details3;
    //public GameObject address3;
    //public GameObject next3;
    //public GameObject prev3;

    //public GameObject crate1;
    //public GameObject crate2;
    //public GameObject crate3;

    public GameObject tutorialScreen;

    public GameObject chips;
    public GameObject addressbook;
    public GameObject cheatsheet;

    public GameObject levelGuideScreen;
    public GameObject extraChipScreen;
    public GameObject systemGuideScreen;

    public AudioClip clickClip;
    AudioSource clickSound;
    public AudioClip closeClip;
    AudioSource closeSound;
    public AudioClip tictocClip;
    AudioSource tictocSound;

    public List<GameObject> details;
    public List<GameObject> addresses;
    public List<GameObject> crates;

    int iterator = 0;

    public void Start()
    {
        clickSound = this.gameObject.AddComponent<AudioSource>();
        clickSound.clip = clickClip;
        clickSound.volume = 0.10f;

        tictocSound = this.gameObject.AddComponent<AudioSource>();
        tictocSound.clip = tictocClip;
        tictocSound.volume = 0.10f;

        closeSound = this.gameObject.AddComponent<AudioSource>();
        closeSound.clip = closeClip;
        closeSound.volume = 0.20f;
    }



    public void ShowDetails()
    {
        addresses[iterator].SetActive(false);
        details[iterator].SetActive(true);
        tictocSound.Play();
    }

    public void ShowAddress()
    {
        details[iterator].SetActive(false);
        addresses[iterator].SetActive(true);
        tictocSound.Play();
    }

    public void InformationNextButton()
    {
        if (iterator < details.Count-1)
        {
            details[iterator].SetActive(false);
            addresses[iterator].SetActive(false);
            crates[iterator].SetActive(false);

            details[iterator+1].SetActive(true);
            crates[iterator+1].SetActive(true);

            iterator++;
        }
        tictocSound.Play();
    }

    public void InformationPrevButton()
    {
        if (iterator >0)
        {
            details[iterator].SetActive(false);
            addresses[iterator].SetActive(false);
            crates[iterator].SetActive(false);

            details[iterator-1].SetActive(true);
            crates[iterator-1].SetActive(true);

            iterator--;
        }
        tictocSound.Play();
    }

    public void ToggleTutorial()
    {
        if (tutorialScreen.activeSelf)
        {
            tutorialScreen.SetActive(false);
        }
        else
            tutorialScreen.SetActive(true);
    }

    //public void showDetailsCrate1()
    //{
    //    details1.SetActive(true);
    //    clickSound.Play();
    //    address1.SetActive(false);
    //}

    //public void showAddressCrate1()
    //{
    //    address1.SetActive(true);
    //    clickSound.Play();
    //    details1.SetActive(false);
    //}

    //public void showDetailsCrate2()
    //{
    //    details2.SetActive(true);
    //    clickSound.Play();
    //    address2.SetActive(false);
    //}

    //public void showAddressCrate2()
    //{
    //    address2.SetActive(true);
    //    clickSound.Play();
    //    details2.SetActive(false);
    //}

    //public void showDetailsCrate3()
    //{
    //    details3.SetActive(true);
    //    clickSound.Play();
    //    address3.SetActive(false);
    //}

    //public void showAddressCrate3()
    //{
    //    address3.SetActive(true);
    //    clickSound.Play();
    //    details3.SetActive(false);
    //}

    //public void nextButtonCrate1()
    //{
    //    crate1.SetActive(false);
    //    crate2.SetActive(true);
    //    details2.SetActive(true);
    //    address2.SetActive(false);
    //    clickSound.Play();
    //}

    //public void prevButtonCrate1()
    //{
    //    closeSound.Play();
    //}

    //public void nextButtonCrate2()
    //{
    //    crate2.SetActive(false);
    //    crate3.SetActive(true);
    //    details3.SetActive(true);
    //    address3.SetActive(false);
    //    clickSound.Play();
    //}

    //public void prevButtonCrate2()
    //{
    //    crate2.SetActive(false);
    //    crate1.SetActive(true);
    //    details1.SetActive(true);
    //    address1.SetActive(false);
    //    clickSound.Play();
    //}

    //public void nextButtonCrate3()
    //{
    //    closeSound.Play();
    //}

    //public void prevButtonCrate3()
    //{
    //    crate3.SetActive(false);
    //    crate2.SetActive(true);
    //    details2.SetActive(true);
    //    address2.SetActive(false);
    //    clickSound.Play();
    //}

    public void chipCollection()
    {
        chips.SetActive(true);
        clickSound.Play();
    }

    public void addressBook()
    {
        addressbook.SetActive(true);
        clickSound.Play();
    }

    public void cheatSheat()
    {
        cheatsheet.SetActive(true);
        clickSound.Play();
    }

    public void close()
    {
        chips.SetActive(false);
        addressbook.SetActive(false);
        cheatsheet.SetActive(false);
        closeSound.Play();
    }

    public void nextButton()
    {
        levelGuideScreen.SetActive(false);
        clickSound.Play();
    }

    public void LevelGuideOpen()
    {
        levelGuideScreen.SetActive(true);
        clickSound.Play();
    }

    public void Extrachip()
    {
        levelGuideScreen.SetActive(false);
        extraChipScreen.SetActive(true);
        clickSound.Play();
    }

    public void ExtrachipClose()
    {
        extraChipScreen.SetActive(false);
        clickSound.Play();
    }

    public void SystemGuideOpen()
    {
        systemGuideScreen.SetActive(true);
        clickSound.Play();
    }

    public void SystemGuideClose()
    {
        systemGuideScreen.SetActive(false);
        clickSound.Play();
    }
}
