using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMarket : MonoBehaviour
{
    public Sprite diverSprite;
    public Sprite newPlayer2;
    public Sprite newPlayer3;
    private ArrayList playerList;

    // Start is called before the first frame update
    void Start()
    {
        playerList.Add(diverSprite);
        playerList.Add(newPlayer2);
        playerList.Add(newPlayer3);
    }
   
    public void setPlayerImage(Sprite newPlayerImage) 
    {
        GameObject diverObject = GameObject.Find("diver");
        PlayerControls playerControlsScript = diverObject.GetComponent<PlayerControls>();
        diverObject.GetComponent<SpriteRenderer>().sprite = newPlayerImage;
        playerControlsScript.setPlayerImage(null, null, newPlayerImage);
    }

    public ArrayList getPlayerSprites()
    {
        return playerList;
    }

}
