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
            "Scenes/Level 1.1/Drone Wiring 1",  //4
            "Scenes/Level 1.1/DroneMove",       //5
            "Scenes/Level 1.2/Chips",           //6
            "Scenes/Level 1.2/Drone Wiring 1",  //7
            "Scenes/Level 1.2/DroneMove",       //8
            "Scenes/Level 2.1/Chips",           //9
            "Scenes/Level 2.1/Drone Wiring 1",  //10
            "Scenes/Level 2.1/DroneMove",       //11
        };
    }

    public void SwitchScene(int sceneNum)
    {
        SceneManager.LoadScene(scenePaths[sceneNum]);
    }
}
