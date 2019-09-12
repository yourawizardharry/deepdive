using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerMovementSpeed;
	private float playerPositioningOffset;

	private Camera cam;

	public void addCamera(Camera cam) 
	{
		this.cam = cam;
		Debug.Log("ADD CAM CALLED");
	}

    // Start is called before the first frame update
    void Start()
    {
        playerMovementSpeed = 0.2f;
		playerPositioningOffset = 4f;
    }

	public void stopMovement()
	{
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
	}

	public void startMovement() 
	{
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
	}

    // Update is called once per frame
    void Update()
    {
        //if(Game.gameRunning)
		movePlayer();
    }

	private void movePlayer() 
	{
		updateCameraPosition(transform.position.y);
	}

	private void updateCameraPosition(float Ypos) 
	{
		if(cam!=null) cam.transform.position = new Vector3(cam.transform.position.x, Ypos-playerPositioningOffset, -10);
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
