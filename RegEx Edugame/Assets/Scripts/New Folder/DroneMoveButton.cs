using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMoveButton : MonoBehaviour
{
    public GameObject droneWire;
    public GameObject wireBG;

    public GameObject crateBag;
    public GameObject crateBagBG;

    public GameObject chipsBag;
    public GameObject chipsBagBG;

    public GameObject house1Detail;
    public GameObject house2Detail;
    public GameObject house3Detail;

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
            droneWire.SetActive(false);
            wireBG.SetActive(false);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            house1Detail.SetActive(false);
            house2Detail.SetActive(false);
            house3Detail.SetActive(false);
        }       
    }

    public void showCrateBag()
    {
        if (crateBag.activeSelf == true)
        {
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
        }

        else if (crateBag.activeSelf == false)
        {
            crateBag.SetActive(true);
            crateBagBG.SetActive(true);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
            droneWire.SetActive(false);
            wireBG.SetActive(false);
            house1Detail.SetActive(false);
            house2Detail.SetActive(false);
            house3Detail.SetActive(false);
        }
    }

    public void showDroneWire()
    {
        if (droneWire.activeSelf == true)
        {
            droneWire.SetActive(false);
            wireBG.SetActive(false);
        }

        else if (droneWire.activeSelf == false)
        {
            droneWire.SetActive(true);
            wireBG.SetActive(true);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
            house1Detail.SetActive(false);
            house2Detail.SetActive(false);
            house3Detail.SetActive(false);
        }
    }

    public void showDroneMove()
    {
        droneWire.SetActive(false);
        wireBG.SetActive(false);
        crateBag.SetActive(false);
        crateBagBG.SetActive(false);
        chipsBag.SetActive(false);
        chipsBagBG.SetActive(false);
        house1Detail.SetActive(false);
        house2Detail.SetActive(false);
        house3Detail.SetActive(false);
    }

    public void showHouse1()
    {
        if (house1Detail.activeSelf == true)
        {
            house1Detail.SetActive(false);
        }

        else if (house1Detail.activeSelf == false)
        {
            house1Detail.SetActive(true);
            house2Detail.SetActive(false);
            house3Detail.SetActive(false);
            droneWire.SetActive(false);
            wireBG.SetActive(false);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
        }
    }
    public void showHouse2()
    {
        if (house2Detail.activeSelf == true)
        {
            house2Detail.SetActive(false);
        }

        else if (house2Detail.activeSelf == false)
        {
            house2Detail.SetActive(true);
            house1Detail.SetActive(false);
            house3Detail.SetActive(false);
            droneWire.SetActive(false);
            wireBG.SetActive(false);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
        }
    }

    public void showHouse3()
    {
        if (house3Detail.activeSelf == true)
        {
            house3Detail.SetActive(false);
        }

        else if (house3Detail.activeSelf == false)
        {
            house3Detail.SetActive(true);
            house1Detail.SetActive(false);
            house2Detail.SetActive(false);
            droneWire.SetActive(false);
            wireBG.SetActive(false);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
        }
    }
}
