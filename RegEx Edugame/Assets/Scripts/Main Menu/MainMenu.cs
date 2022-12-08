using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    AudioSource audioSource;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void PlayGame(){
        audioSource = playButton.GetComponent<AudioSource>();
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}