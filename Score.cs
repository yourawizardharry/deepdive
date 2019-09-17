using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    

    // Update is called once per frame
    void Update()
    {
        float depth = player.position.y * (-1)/10;
        scoreText.text = depth.ToString("0");
    }
}
