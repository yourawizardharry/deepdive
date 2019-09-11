using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	private float sensitivity = 10;
	public Camera camera;
	public float boundMin, boundMax;

	void Start() {

            if(GameObject.FindWithTag("MainCamera")!= null) camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            if(camera!=null) getBounds();
	}

    public void addCamera(Camera cam)
    {
        this.camera = cam;
        getBounds();
    }

    // Update is called once per frame
    void Update()
    {
		if(Game.gameRunning && camera != null) {
		updatePosition(getNewPosition());
		}
    }


	bool isWithinBounds(float x) {
		if(x+transform.position.x < boundMax && x+transform.position.x > boundMin) {
			return true;
		}
		else return false;
	}

	void getBounds() {
		boundMax = (camera.aspect * camera.orthographicSize) - 1;
		boundMin = boundMax*-1;
	}


	float getNewPosition() {
		return Input.acceleration.x*sensitivity*Time.deltaTime;
	}

	public void updatePosition(float newPosition) {
		if(isWithinBounds(newPosition)) transform.Translate(newPosition, 0, 0);
	}

	bool setSensitivity(float sensitivity) {
		if(sensitivity < 20 && sensitivity > 5) {
			this.sensitivity = sensitivity;
			return true;
		}
		else return false;
	}



}
