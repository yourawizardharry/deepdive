using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	Slider slider;
	
	void Start() {
		slider = GameObject.Find("Slider").GetComponent<Slider>();
		if(PlayerPrefs.HasKey("sensitivity")) slider.value = PlayerPrefs.GetFloat("sensitivity");
		slider.onValueChanged.AddListener(delegate {callBackSlider(slider.value);});
	}

	 public void callBackSlider(float newValue)
 {
	Debug.Log(newValue);
     PlayerControls.setSensitivity(newValue);
	 PlayerPrefs.SetFloat("sensitivity", newValue);
 }

 public void returnToMenu() {
	SceneManager.LoadScene(0);
 }

}
