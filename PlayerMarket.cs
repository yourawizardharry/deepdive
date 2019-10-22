using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMarket : MonoBehaviour
{
    private string saveKey = "playerImg";
    private string player1 = "diver";
    private string player2 = "shark";
    private string player3 = "noimage";
    public Sprite curSprite;
    public GameObject diverObject;
    private ArrayList playerList;
    public Sprite[] playerImages;


    // Start is called before the first frame update
    //D
    void Start()
    {
        if (!PlayerPrefs.HasKey(player1)) PlayerPrefs.SetInt(player1, 1);
        if (!PlayerPrefs.HasKey(saveKey)) PlayerPrefs.SetInt(saveKey, 0);

        Debug.Log("skeet");

        playerList = new ArrayList();
        for (int i = 0; i < playerImages.Length; ++i)
        {
            playerList.Add(playerImages[i]);
        }

        if (PlayerPrefs.HasKey(saveKey))
        {
            curSprite = (Sprite)playerList.ToArray()[PlayerPrefs.GetInt(saveKey)];
            this.setPlayerImage(curSprite);
        }
        else
        {
            curSprite = playerImages[0];
        }

    }

    public bool checkOwned(Sprite image)
    {
        if (image == playerImages[0])
        {
            if (PlayerPrefs.HasKey(player1))
            {
                if (PlayerPrefs.GetInt(player1) == 1) return true;
                return false;
            }
        }
        if (image == playerImages[1])
        {
            if (PlayerPrefs.HasKey(player2))
            {
                if (PlayerPrefs.GetInt(player2) == 1) return true;
                return false;
            }
        }
        if (image == playerImages[2])
        {
            if (PlayerPrefs.HasKey(player3))
            {
                if (PlayerPrefs.GetInt(player3) == 1) return true;
            }
        }
        return false;
    }

    public void saveCurrentImageSelection()
    {
        if (playerList.Contains(curSprite)) PlayerPrefs.SetInt(saveKey, playerList.IndexOf(curSprite));
    }

    public void setPlayer(int newPlayerImage)
    {
        this.Start();
        Debug.Log("yeet");
        if (diverObject != null)
        {
            Debug.Log("noot");
            PlayerControls playerControlsScript = diverObject.GetComponent<PlayerControls>();
            diverObject.GetComponent<SpriteRenderer>().sprite = playerImages[newPlayerImage];
            playerControlsScript.setPlayerImage(null, null, playerImages[newPlayerImage]);
            
        }
        curSprite = (Sprite)playerImages[newPlayerImage];
    }

    public void setPlayerImage(Sprite newImage)
    {
        if (diverObject != null)
        {
            if (newImage == playerImages[0])
            {
                PlayerPrefs.SetInt(player1, 1);
            }

            PlayerControls playerControlsScript = diverObject.GetComponent<PlayerControls>();
            diverObject.GetComponent<SpriteRenderer>().sprite = newImage;
            playerControlsScript.setPlayerImage(null, null, newImage);
            curSprite = newImage;
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
