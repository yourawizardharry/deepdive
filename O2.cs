using System;
using UnityEngine;
using UnityEngine.UI;

public class O2 : MonoBehaviour
{
    public Text O2Text;
    public float oxygenLeft = 100.0f;
    public GameObject airWarning;

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject, 0.1f);
        increaseO2();

    }
    void increaseO2()
    {
        oxygenLeft += 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && Game.gameRunning)
        {
            oxygenLeft -= Time.deltaTime;
            O2Text.text = "O2 Left " + oxygenLeft.ToString("0") + "%";
        }

        if (oxygenLeft < 20)
        {
            airWarning.SetActive(true);
        }
        else if (oxygenLeft > 20)
        {
            airWarning.SetActive(false);
        }

        else if (oxygenLeft < 0)
        {
            GameObject.Find("Game_Manager").GetComponent<Game>().stopGame();
        }

    }
}
