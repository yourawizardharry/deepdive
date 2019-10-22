using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static float playerMovementSpeed = 0.2f;
	private float playerPositioningOffset;
    private bool running = true;
	private Camera cam;

	public void addCamera(Camera cam) 
	{
		this.cam = cam;
		Debug.Log("ADD CAM CALLED");
	}


    // Start is called before the first frame update
    void Start()
    {
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

    public void Invinsable()
    {
        GetComponent<PolygonCollider2D>().enabled = false; 
        Invoke("normal",3.0f); 
    }

    public void normal()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
    }

    public float getSpeed()
    {
        return GetComponent<Rigidbody2D>().gravityScale;
    }

    public void speed_up()
    {
        GetComponent<Rigidbody2D>().gravityScale = 3.0f;
        Invoke("normal_speed", 3.0f); 
    }

    public void normal_speed()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(running) {
			movePlayer();
		}
		Debug.Log(playerMovementSpeed);
    }

    public void isRunning(bool running)
    {
        this.running = running;
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

	public static void setPlayerSpeed(float speed) 
	{
		if(speed > 0 && speed <=1) {
			playerMovementSpeed = speed;
		}
	}
}
