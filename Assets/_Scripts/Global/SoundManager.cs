using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	Slider soundSlider;
	Text soundValueText;

	void Awake()
	{
		soundSlider = GameObject.Find("SoundSlider").GetComponent<Slider>();
		soundValueText = GameObject.Find("soundNumberValue").GetComponent<Text>();
		soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
	}

	
	void Update () 
	{
		float procents = Mathf.Round(soundSlider.value * 100f);
		soundValueText.text = procents.ToString();
		AudioListener.volume = soundSlider.value;
	}
}
