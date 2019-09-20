using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NUnit.Framework;

public class PauseMenu_Test : MonoBehaviour
{
    public GameObject pauseMenuUI;
    bool isGameOver;

    [Test]
    public void Pause_Test()
    {
        if (Time.timeScale == 1) //pause
        {
            Time.timeScale = 0;
            pauseMenuUI.SetActive(true);
        }
        else if (Time.timeScale == 0) //resume
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
        }
    }

    [Test]
    public void Update_Test()
    {
        Pause_Test();
    }

    [Test]
    public void loadMenu_Test()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    [Test]
    public void quit_Test()
    {
        Debug.Log("Quitting game....");
        Application.Quit();
    }
}
