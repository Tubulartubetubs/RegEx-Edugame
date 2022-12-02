using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clicking UIs
public class DroneMoveButton : MonoBehaviour
{
    public GameObject crateBag;
    public GameObject crateBagBG;

    public GameObject chipsBag;
    public GameObject chipsBagBG;

    public GameObject house1Detail;
    public GameObject house2Detail;
    public GameObject house3Detail;
    public GameObject house4Detail;

    public GameObject droneSelected;
    public GameObject chipsSelected;

    public AudioSource clickingUI;

    public SwitchScenes scenePass;

    public MovingObject player;


    public void showDroneMove()
    {
        crateBag.SetActive(false);
        crateBagBG.SetActive(false);
        chipsBag.SetActive(false);
        chipsBagBG.SetActive(false);
        house1Detail.SetActive(false);
        house2Detail.SetActive(false);
        house3Detail.SetActive(false);
        house4Detail.SetActive(false);
        chipsSelected.SetActive(false);
        droneSelected.SetActive(true);
        clickingUI.Play();
        player.DroneSoundUp();
    }

    public void showChipsBag()
    {
        if (chipsBag.activeSelf == true) {
            showDroneMove();
        }

        else if (chipsBag.activeSelf == false)
        {
            chipsBag.SetActive(true);
            chipsBagBG.SetActive(true);
            chipsSelected.SetActive(true);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            house1Detail.SetActive(false);
            house2Detail.SetActive(false);
            house3Detail.SetActive(false);
            house4Detail.SetActive(false);
            droneSelected.SetActive(false);
            clickingUI.Play();
            player.DroneSoundDown();
        }       
    }

    public void showCrateBag()
    {
        if (crateBag.activeSelf == true)
        {
            showDroneMove();
        }

        else if (crateBag.activeSelf == false)
        {
            crateBag.SetActive(true);
            crateBagBG.SetActive(true);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
            house1Detail.SetActive(false);
            house2Detail.SetActive(false);
            house3Detail.SetActive(false);
            house4Detail.SetActive(false);
            chipsSelected.SetActive(false);
            clickingUI.Play();
            player.DroneSoundUp();
        }
    }

    public void showHouse1()
    {
        if (house1Detail.activeSelf == true)
        {
            showDroneMove();
        }

        else if (house1Detail.activeSelf == false)
        {
            house1Detail.SetActive(true);
            house2Detail.SetActive(false);
            house3Detail.SetActive(false);
            house4Detail.SetActive(false);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
            chipsSelected.SetActive(false);
            droneSelected.SetActive(false);
            clickingUI.Play();
            player.DroneSoundDown();
        }
    }
    public void showHouse2()
    {
        if (house2Detail.activeSelf == true)
        {
            showDroneMove();
        }

        else if (house2Detail.activeSelf == false)
        {
            house2Detail.SetActive(true);
            house1Detail.SetActive(false);
            house3Detail.SetActive(false);
            house4Detail.SetActive(false);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
            chipsSelected.SetActive(false);
            droneSelected.SetActive(false);
            clickingUI.Play();
            player.DroneSoundDown();
        }
    }

    public void showHouse3()
    {
        if (house3Detail.activeSelf == true)
        {
            showDroneMove();
        }

        else if (house3Detail.activeSelf == false)
        {
            house3Detail.SetActive(true);
            house1Detail.SetActive(false);
            house2Detail.SetActive(false);
            house4Detail.SetActive(false);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
            chipsSelected.SetActive(false);
            droneSelected.SetActive(false);
            clickingUI.Play();
            player.DroneSoundDown();
        }
    }

    public void showHouse4()
    {
        if (house4Detail.activeSelf == true)
        {
            showDroneMove();
        }

        else if (house4Detail.activeSelf == false)
        {
            house4Detail.SetActive(true);
            house1Detail.SetActive(false);
            house2Detail.SetActive(false);
            house3Detail.SetActive(false);
            crateBag.SetActive(false);
            crateBagBG.SetActive(false);
            chipsBag.SetActive(false);
            chipsBagBG.SetActive(false);
            chipsSelected.SetActive(false);
            droneSelected.SetActive(false);
            clickingUI.Play();
            player.DroneSoundDown();
        }
    }

    public void targetScene(int nextScene)
    {
        scenePass.SwitchScene(nextScene); //move to nextscene
    }

    public void mapScene()
    {
        scenePass.SwitchScene(2); // replace nextScene to map scene number
    }
}
