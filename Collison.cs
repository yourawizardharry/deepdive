using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison : MonoBehaviour
{
    public GameObject restartPanel;
    public uiManager ui;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision");

        restartPanel.SetActive(true);
        GameObject.Find("Game_Manager").GetComponent<Game>().stopGame();
        ui.gameOver();
    }

    private void Start()
    {
        ui.GetComponent<uiManager>();
    }

    // Update is called once per frame
    void Update()
    {



    }
}