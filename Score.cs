using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    float depth;

    // Update is called once per frame
    void Update()
    {
	if(Time.timeScale == 1 && Game.gameRunning)
        {
            depth = GameObject.Find("Game_Manager").GetComponent<Game>().Player.transform.position.y * (-1) /10 - 4;
            scoreText.text = "Score: " + depth.ToString("0") + "m";
		}
    }

    

}