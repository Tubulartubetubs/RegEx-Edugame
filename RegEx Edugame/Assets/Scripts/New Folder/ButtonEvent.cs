using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public GameObject details1;
    public GameObject address1;
    public GameObject next1;
    public GameObject prev1;

    public GameObject details2;
    public GameObject address2;
    public GameObject next2;
    public GameObject prev2;

    public GameObject details3;
    public GameObject address3;
    public GameObject next3;
    public GameObject prev3;

    public GameObject crate1;
    public GameObject crate2;
    public GameObject crate3;

    public GameObject chips;
    public GameObject addressbook;
    public GameObject cheatsheet;

    public void showDetailsCrate1()
    {
        details1.SetActive(true);

        address1.SetActive(false);
    }

    public void showAddressCrate1()
    {
        address1.SetActive(true);

        details1.SetActive(false);
    }

    public void showDetailsCrate2()
    {
        details2.SetActive(true);

        address2.SetActive(false);
    }

    public void showAddressCrate2()
    {
        address2.SetActive(true);

        details2.SetActive(false);
    }

    public void showDetailsCrate3()
    {
        details3.SetActive(true);

        address3.SetActive(false);
    }

    public void showAddressCrate3()
    {
        address3.SetActive(true);

        details3.SetActive(false);
    }

    public void nextButtonCrate1()
    {
        crate1.SetActive(false);
        crate2.SetActive(true);
        details2.SetActive(false);
    }

    public void prevButtonCrate1()
    {

    }

    public void nextButtonCrate2()
    {
        crate2.SetActive(false);
        crate3.SetActive(true);
        details3.SetActive(false);
    }

    public void prevButtonCrate2()
    {
        crate2.SetActive(false);
        crate1.SetActive(true);
        details2.SetActive(false);
    }

    public void nextButtonCrate3()
    {
        
    }

    public void prevButtonCrate3()
    {
        crate3.SetActive(false);
        crate2.SetActive(true);
        details2.SetActive(false);
    }

    public void chipCollection()
    {
        chips.SetActive(true);
    }

    public void addressBook()
    {
        addressbook.SetActive(true);
    }

    public void cheatSheat()
    {
        cheatsheet.SetActive(true);
    }

    public void close()
    {
        chips.SetActive(false);
        addressbook.SetActive(false);
        cheatsheet.SetActive(false);
    }
}
