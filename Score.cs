using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;

    private void Start()
    {
        player = Instantiate(player);
    }
    // Update is called once per frame
    void Update()
    {
        float depth = player.transform.position.y * (-1) / 10 - 4;
        scoreText.text = "Score: " + depth.ToString("0");
    }

    public void addPlayer(GameObject player)
    {
        //this.player = GameObject.Find("player").transform;
        this.player = player;
    }
}