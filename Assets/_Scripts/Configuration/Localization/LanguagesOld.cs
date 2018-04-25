using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguagesOld : MonoBehaviour
{
	Slider languageSlider;

	void Awake () 
	{
		languageSlider = GameObject.Find("languageSlider").GetComponent<Slider>();
		PlayerPrefs.GetString("gameLanguage");
		if (PlayerPrefs.GetString("gameLanguage") == "English")
			languageSlider.value = 1;
		else languageSlider.value = 0;
	}

	void Update()
	{
		if (languageSlider.value == 1)
			PlayerPrefs.SetString("gameLanguage", "English");
		else if (languageSlider.value == 0)
				PlayerPrefs.SetString("gameLanguage", "Polish");
	}
}
