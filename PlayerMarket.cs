using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMarket : MonoBehaviour
{
    private string saveKey = "playerImg";
    public Sprite diverSprite;
    public Sprite newPlayer2;
    public Sprite newPlayer3;
    public Sprite curSprite;
    private ArrayList playerList;

    // Start is called before the first frame update
    void Start()
    {
        playerList = new ArrayList();
        playerList.Add(diverSprite);
        playerList.Add(newPlayer2);
        playerList.Add(newPlayer3);
        if(PlayerPrefs.HasKey(saveKey))
        {
            curSprite = (Sprite)playerList.ToArray()[PlayerPrefs.GetInt(saveKey)];
        }
        else
        {
            curSprite = diverSprite;
        }
        setPlayerImage(curSprite);
    }

    public void saveCurrentImageSelection()
    {
        if (playerList.Contains(curSprite)) PlayerPrefs.SetInt(saveKey, playerList.IndexOf(curSprite));
    }
   
    public void setPlayerImage(Sprite newPlayerImage) 
    {
        GameObject diverObject = GameObject.Find("diver");
        PlayerControls playerControlsScript = diverObject.GetComponent<PlayerControls>();
        diverObject.GetComponent<SpriteRenderer>().sprite = newPlayerImage;
        playerControlsScript.setPlayerImage(null, null, newPlayerImage);
        curSprite = newPlayerImage;
    }

    public ArrayList getPlayerSprites()
    {
        return playerList;
    }

}
