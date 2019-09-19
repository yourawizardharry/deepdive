using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public void Pause()
    {
        if (Time.timeScale == 1) //pause
        {
            Time.timeScale = 0;
            pauseMenuUI.SetActive(false);
            gameIsPaused = true;
        }
        else if (Time.timeScale == 0) //resume
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(true);
            gameIsPaused = false;
        }
    }

    private void Update()
    {
        Pause();
    }

    public void resume()
    {
        Pause();
    }

    public void loadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void quit()
    {
        Debug.Log("Quitting game...."); 
        Application.Quit();
    }
}
