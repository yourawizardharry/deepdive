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
    private GameObject diverObject;
    private ArrayList playerList;
    public Sprite[] playerImages;

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
    }

    public void saveCurrentImageSelection()
    {
        if (playerList.Contains(curSprite)) PlayerPrefs.SetInt(saveKey, playerList.IndexOf(curSprite));
    }
   
    public void setPlayerImage(int newPlayerImage) 
    {
        if (diverObject != null)
        {
            PlayerControls playerControlsScript = diverObject.GetComponent<PlayerControls>();
            diverObject.GetComponent<SpriteRenderer>().sprite = playerImages[newPlayerImage];
            playerControlsScript.setPlayerImage(null, null, playerImages[newPlayerImage]);
            curSprite = playerImages[newPlayerImage];
        }
    }

    public void setPlayer(GameObject diverObject)
    {
        this.diverObject = diverObject;
    } 

    public ArrayList getPlayerSprites()
    {
        return playerList;
    }

}
