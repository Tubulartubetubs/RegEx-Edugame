using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public List<string> scenePaths;

    // Start is called before the first frame update
    void Start()
    {
        scenePaths = new List<string>()
        {
            "Scenes/MainMenu",                  //0
            "Scenes/Intro",                     //1
            "Scenes/LevelSelect",               //2
            "Scenes/Level 1.1/Chips",           //3
            "Scenes/Level 1.1/Drone Wiring",    //4
            "Scenes/Level 1.1/DroneMove",       //5
            "Scenes/Level 1.2/Chips",           //6
            "Scenes/Level 1.2/Drone Wiring",    //7
            "Scenes/Level 1.2/DroneMove",       //8

            "Scenes/Level 2.1/Chips",           //9
            "Scenes/Level 2.1/Drone Wiring",    //10
            "Scenes/Level 2.1/DroneMove",       //11
            "Scenes/Level 2.2/Chips",           //12
            "Scenes/Level 2.2/Drone Wiring",    //13
            "Scenes/Level 2.2/DroneMove",       //14

            "Scenes/Level 3.1/Chips",           //15
            "Scenes/Level 3.1/Drone Wiring",    //16
            "Scenes/Level 3.1/DroneMove",       //17
            "Scenes/Level 3.2/Chips",           //18
            "Scenes/Level 3.2/Drone Wiring",    //19
            "Scenes/Level 3.2/DroneMove",       //20
            "Scenes/Level 3.3/Chips",           //21
            "Scenes/Level 3.3/Drone Wiring",    //22
            "Scenes/Level 3.3/DroneMove",       //23
            "Scenes/Level 3.4/Chips",           //24
            "Scenes/Level 3.4/Drone Wiring",    //25
            "Scenes/Level 3.4/DroneMove",       //26

            "Scenes/Level 4.1/Chips",           //27
            "Scenes/Level 4.1/Drone Wiring",    //28
            "Scenes/Level 4.1/DroneMove",       //29
            "Scenes/Level 4.2/Chips",           //30
            "Scenes/Level 4.2/Drone Wiring",    //31
            "Scenes/Level 4.2/DroneMove",       //32
            "Scenes/Level 4.3/Chips",           //33
            "Scenes/Level 4.3/Drone Wiring",    //34
            "Scenes/Level 4.3/DroneMove",       //35
            "Scenes/Level 4.4/Chips",           //36
            "Scenes/Level 4.4/Drone Wiring",    //37
            "Scenes/Level 4.4/DroneMove",       //38
            "Scenes/Level 4.5/Chips",           //39
            "Scenes/Level 4.5/Drone Wiring",    //49
            "Scenes/Level 4.5/DroneMove",       //41
            "Scenes/Level 4.6/Chips",           //42
            "Scenes/Level 4.6/Drone Wiring",    //43
            "Scenes/Level 4.6/DroneMove",       //44

            "Scenes/Level 5.1/Chips",           //45
            "Scenes/Level 5.1/Drone Wiring",    //46
            "Scenes/Level 5.1/DroneMove",       //47
            "Scenes/Level 5.2/Chips",           //48
            "Scenes/Level 5.2/Drone Wiring",    //49
            "Scenes/Level 5.2/DroneMove",       //50

            "Scenes/Level 6.1/Chips",           //51
            "Scenes/Level 6.1/Drone Wiring",    //52
            "Scenes/Level 6.1/DroneMove",       //53
            "Scenes/Level 6.2/Chips",           //54
            "Scenes/Level 6.2/Drone Wiring",    //55
            "Scenes/Level 6.2/DroneMove",       //56
            "Scenes/Level 6.3/Chips",           //57
            "Scenes/Level 6.3/Drone Wiring",    //58
            "Scenes/Level 6.3/DroneMove",       //59

            "Scenes/Level 7.1/Chips",           //60
            "Scenes/Level 7.1/Drone Wiring",    //61
            "Scenes/Level 7.1/DroneMove",       //62
            "Scenes/Level 7.2/Chips",           //63
            "Scenes/Level 7.2/Drone Wiring",    //64
            "Scenes/Level 7.2/DroneMove",       //65
            "Scenes/Level 7.3/Chips",           //66
            "Scenes/Level 7.3/Drone Wiring",    //67
            "Scenes/Level 7.3/DroneMove",       //68
            "Scenes/Level 7.4/Chips",           //69
            "Scenes/Level 7.4/Drone Wiring",    //70
            "Scenes/Level 7.4/DroneMove",       //71
            "Scenes/Level 7.5/Chips",           //72
            "Scenes/Level 7.5/Drone Wiring",    //73
            "Scenes/Level 7.5/DroneMove",       //74

            "Scenes/Tutorialcont/Intro",         //75
            "Scenes/Tutorialcont/SceneTutorials" //76
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SwitchScene(int sceneNum)
    {
        SceneManager.LoadScene(scenePaths[sceneNum]);
    }
}
