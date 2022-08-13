using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button playAgain;
    public Button quit;
    public void startAgain()
    {
        SceneManager.LoadScene("PlayMode");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
