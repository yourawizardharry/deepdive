using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessOverlay : MonoBehaviour
{
	private Camera cam;
	private bool running = false;
	private float curTransparency = 0f;

	void Start() 
	{
		InvokeRepeating("incrementTransparency", 2, 2);
	}

    // Update is called once per frame
    void Update()
    {
		if(cam != null && running) {
			Vector3 camPOS = cam.transform.position;
			camPOS.z = 0;
			transform.position = camPOS;
		}
    }

	public void addCamera(Camera cam) {
		this.cam = cam;
	}

	private void incrementTransparency() 
	{
		if(running && curTransparency < 0.8f) 
		{
			curTransparency += 0.02f;
			setTransparency(curTransparency);
		}
	}

	public float getTransparency() 
	{
		return curTransparency;
	}

	public bool setTransparency(float alpha) 
	{
		if(alpha >= 0.0f && alpha <= 1) 
		{
			this.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,alpha);
			return true;
		}
		else return false;
	}

	public void voidSetPaused(bool paused)
	{
		running = false;
	}

	public void setRunning(bool isRunning)
	{
		if(!isRunning) {
			curTransparency = 100;
			setTransparency(curTransparency);
			running = false;
		}
		else running = true;
	}
}
