using UnityEngine;
using UnityEngine.UI;

public class O2 : MonoBehaviour
{
    public Transform player;
    public Text scoreText;


    // Update is called once per frame
    void Update()
    {
        float oxygenLeft = 100 - player.position.y * (-1) / 80; ;
        if (oxygenLeft > 0)
        {
            scoreText.text = "Oxygen " + oxygenLeft.ToString("0") + "%";
        }
    }
}
