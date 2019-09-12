using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	private float sensitivity = 15;
	GameObject camera;
	float boundMin, boundMax;
	public Sprite leftImage, rightImage, downImage;

	void Start() {
		camera = GameObject.FindWithTag("MainCamera");
		getBounds();
	}

    // Update is called once per frame
    void Update()
    {
		if(Game.gameRunning) {
		float acceleration = getAcceleration();
		if(acceleration > 1.2f / sensitivity) setImage(rightImage);
		else if(acceleration < -1.2f / sensitivity) setImage(leftImage);
		else if(acceleration > -0.6f / sensitivity && acceleration < 0.6f / sensitivity) setImage(downImage);
		updatePosition(getPosition(acceleration));
		}
    }

	void setImage(Sprite image) {
	if(image!=null) GetComponent<SpriteRenderer>().sprite = image;
	else Debug.Log("imagenull");
	}


	bool isWithinBounds(float x) {
		if(x+transform.position.x < boundMax && x+transform.position.x > boundMin) {
			return true;
		}
		else return false;
		
	}

	void getBounds() {
		boundMax = (camera.GetComponent<Camera>().aspect * camera.GetComponent<Camera>().orthographicSize) - 1;
		boundMin = boundMax*-1;
	}

	float getAcceleration() 
	{
		return Input.acceleration.x;
	}

	float getPosition(float acceleration) {
		return acceleration*sensitivity*Time.deltaTime;
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
