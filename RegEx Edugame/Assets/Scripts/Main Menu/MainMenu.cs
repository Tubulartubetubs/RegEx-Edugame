using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    AudioSource audioSource;

    public void PlayGame(){
        audioSource = playButton.GetComponent<AudioSource>();
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}