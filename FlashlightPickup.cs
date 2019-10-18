using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col) 
	{
		Destroy(gameObject, 0.1f);
		DarknessOverlay darknessOverlay = (DarknessOverlay) GameObject.Find("Game_Manager").GetComponent<Game>().darknessOverlayScript;
		float curTransparency = darknessOverlay.getTransparency();
		if(curTransparency > 0.10f) {
			darknessOverlay.setTransparency(curTransparency - 0.10f);
		} 
	}
}
