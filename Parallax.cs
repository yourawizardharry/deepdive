using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject backGround1, backGround2;
    RectTransform rt;
    float backGround1LocY, backGround2LocY;
    float cameraLocY;

    void Start()
    {
        getBackgrounds();
    }


    // Update is called once per frame
    void Update()
    {
		if(Game.gameRunning) {
			if (backGround1 == null || backGround2 == null)
			{
			    getBackgrounds();
			}
			else backGroundUpdate();
		}
    }


    public void backGroundUpdate()
    {
        if (backGround1 != null && backGround2 != null)
        {
            backGround1LocY = backGround1.transform.position.y - (backGround1.GetComponent<SpriteRenderer>().bounds.size.y / 2f);
            backGround2LocY = backGround2.transform.position.y - (backGround2.GetComponent<SpriteRenderer>().bounds.size.y / 2f);
            cameraLocY = GetComponent<Camera>().transform.position.y - GetComponent<Camera>().orthographicSize;

            if (cameraLocY < backGround1LocY + -1 * backGround1.GetComponent<SpriteRenderer>().bounds.size.y)
            {
                moveBackground(backGround1, backGround2);
            }
            else if (cameraLocY < backGround2LocY + -1 * backGround2.GetComponent<SpriteRenderer>().bounds.size.y)
            {
                moveBackground(backGround2, backGround1);
            }
        }
    }

    public void getBackgrounds()
    {
        backGround1 = GameObject.Find("underwater");
        backGround2 = GameObject.Find("underwater2");
    }

    public void moveBackground(GameObject backgroundToMove, GameObject backGroundCompare)
    {
        Vector3 temp = backGroundCompare.transform.position;
        temp.y += (-1 * backGroundCompare.GetComponent<SpriteRenderer>().bounds.size.y);
        backgroundToMove.transform.position = temp;
    }
}
