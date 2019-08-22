using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject backGround1, backGround2;
    RectTransform rt;
    float backGround1LocY, backGround2LocY;
    float cameraLocY;


    // Update is called once per frame
    void Update()
    {
        if (backGround1 == null || backGround2 == null)
        {
            backGround1 = GameObject.Find("underwater");
            backGround2 = GameObject.Find("underwater2");
        }
        else if (backGround1 != null && backGround2 != null)
        {
            backGround1LocY = backGround1.transform.position.y - (backGround1.GetComponent<SpriteRenderer>().bounds.size.y / 2f);
            backGround2LocY = backGround2.transform.position.y - (backGround2.GetComponent<SpriteRenderer>().bounds.size.y / 2f);
            cameraLocY = GetComponent<Camera>().transform.position.y - GetComponent<Camera>().orthographicSize;

            if(cameraLocY < backGround1LocY + -1*backGround1.GetComponent<SpriteRenderer>().bounds.size.y)
            {
                Vector3 temp1 = backGround2.transform.position;
                temp1.y += (-1 * backGround2.GetComponent<SpriteRenderer>().bounds.size.y);
                backGround1.transform.position = temp1;
            }
            else if (cameraLocY < backGround2LocY + -1 * backGround2.GetComponent<SpriteRenderer>().bounds.size.y)
            {
                Vector3 temp2 = backGround1.transform.position;
                temp2.y += (-1 * backGround1.GetComponent<SpriteRenderer>().bounds.size.y);
                backGround2.transform.position = temp2;
            }
        }
    }
}
