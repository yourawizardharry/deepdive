using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerMovementSpeed;
	private float playerPositioningOffset;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementSpeed = 0.2f;
		playerPositioningOffset = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Game.gameRunning) movePlayer();
    }

	private void movePlayer() 
	{
		Vector3 newPostition = getNewPosition();
        transform.position = newPostition;
		updateCameraPosition(newPostition.y);
	}

	private void updateCameraPosition(float Ypos) 
	{
		Camera.main.transform.position = new Vector3(GameObject.FindWithTag("MainCamera").transform.position.x, Ypos-playerPositioningOffset, -10);
	}

	private Vector3 getNewPosition() 
	{
		Vector3 vect = transform.position;
        vect.y -= playerMovementSpeed;
		return vect;
	}

	void setPlayerSpeed(float speed) 
	{
		if(speed > 0 && speed <=1) {
			playerMovementSpeed = speed;
		}
	}
}
