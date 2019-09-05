using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	private float sensitivity = 10;
	GameObject camera;
	float boundMin, boundMax;

	void Start() {
		camera = GameObject.FindWithTag("MainCamera");
		getBounds();
	}

    // Update is called once per frame
    void Update()
    {
		if(Game.gameRunning) {
		updatePosition(getPosition());
		Debug.Log(transform.position.x);
		}
    }


	bool isWithinBounds(float x) {
		Debug.Log("X: " + x);
		if(x+transform.position.x < boundMax && x+transform.position.x > boundMin) {
			return true;
		}
		else return false;
		
	}

	void getBounds() {
		boundMax = (camera.GetComponent<Camera>().aspect * camera.GetComponent<Camera>().orthographicSize) - 1;
		boundMin = boundMax*-1;
	}


	float getPosition() {
		return Input.acceleration.x*sensitivity*Time.deltaTime;
	}

	void updatePosition(float acceleration) {
		if(isWithinBounds(acceleration)) transform.Translate(acceleration, 0, 0);
	}

	bool setSensitivity(float sensitivity) {
		if(sensitivity < 20 && sensitivity > 5) {
			this.sensitivity = sensitivity;
			return true;
		}
		else return false;
	}

}
