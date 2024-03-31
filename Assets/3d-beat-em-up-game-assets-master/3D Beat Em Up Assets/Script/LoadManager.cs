using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;

    public GameObject pause;
    public GameObject resume;
    public GameObject menu;

    bool isPaused = true;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void PlayAgain2()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void Pause()
    {
        if (isPaused == true )
        {
            pause.SetActive(false);
            Time.timeScale = 0;
            resume.SetActive(true);
            menu.SetActive(true);
        }
        else
        {
            pause.SetActive(true);
            Time.timeScale = 1;
            pause.SetActive(true);
            resume.SetActive(false);
            menu.SetActive(false);
        }

        isPaused = !isPaused;
    }

}
