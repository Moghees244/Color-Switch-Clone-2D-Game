using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Button play;
    public Button quit;
    public GameObject audioSource;
    public AudioClip[] clip;

    private void Start()
    {
        audioSource.GetComponent<AudioSource>().clip = clip[0];
        audioSource.GetComponent<AudioSource>().Play();
    }

    public void playGame()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(clip[1]);
        SceneManager.LoadScene("PlayMode");
    }

    public void quitGame()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(clip[1]);
        Application.Quit();
    }
}
