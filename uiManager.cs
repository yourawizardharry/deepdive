using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    bool isGameOver;
    //public Text scoreText;
    //int score;
    public Text speedText;

    private void Start()
    {
        isGameOver = false;
        //score = 0;
        //InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
    }

    public void Pause()
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

    private void Update()
    {
        Pause();
        //scoreText.text = "Score: " + score + "m";
        speedText.text = GameObject.Find("Game_Manager").GetComponent<Game>().PlayerInstanceMovementScript.getSpeed().ToString("0");
    }

    //void scoreUpdate()
    //{
    //    if(!isGameOver)
    //    {
    //    score += 1;
    //    }
    //}

    public void gameOver()
    {
        isGameOver = true;
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