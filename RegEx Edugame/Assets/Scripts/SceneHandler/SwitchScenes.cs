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
            "Scenes/MainMenu",              //0
            "Scenes/Intro",                 //1
            "Scenes/LevelSelect",           //2
            "Scenes/Level 1/Level 1",       //3
            "Scenes/Level 1/Drone Wiring 1",//4
            "Scenes/Level 1/DroneMove"      //5
        };
    }

    public void SwitchScene(int sceneNum)
    {
        SceneManager.LoadScene(scenePaths[sceneNum]);
    }
}
