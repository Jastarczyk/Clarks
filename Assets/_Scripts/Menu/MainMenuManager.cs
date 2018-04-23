using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour 
{

	public GameObject prefsPanel;
	public GameObject creditsPanel;
	public GameObject controlPanel;

	public Text languageText;
	public Text polskiText;
	public Text englishText;
	public Text applyText;

	public Text developerText;
	public Text testersText;

    public Text[] controlText;

	void Start () 
	{
		prefsPanel.SetActive(false);
		creditsPanel.SetActive(false);
		controlPanel.SetActive(false);

		AudioListener.volume = PlayerPrefs.GetFloat("soundVolume");
	}

	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
		   DisActivePrefPanel();
			creditsPanel.SetActive(false);
			controlPanel.SetActive(false);
		}

		if(PlayerPrefs.GetString("gameLanguage") == "Polish")
		{
            //load JSON

            controlText[0].text = "do góry";
            controlText[1].text = "w lewo";
            controlText[2].text = "w prawo";
            controlText[3].text = "w dół";
            controlText[4].text = "strzał";
            controlText[5].text = "przeładowanie";
            controlText[6].text = "latarka";

            languageText.text = "Język";
			polskiText.text = "polski";
			englishText.text = "angielski";
			applyText.text = "Zapisz";
			developerText.text = "Projektant: ";
			testersText.text = "Testerzy: ";
		}
		else 
		{
            controlText[0].text = "up";
            controlText[1].text = "left";
            controlText[2].text = "right";
            controlText[3].text = "down";
            controlText[4].text = "shot";
            controlText[5].text = "reload";
            controlText[6].text = "flashlight";

            languageText.text = "Language";
			polskiText.text = "polish";
			englishText.text = "english";
			applyText.text = "Save";
			developerText.text = "Developer: ";
			testersText.text = "Testers: ";
		}
	}


	public void OnPrefClick()
	{
		prefsPanel.SetActive(true);
		creditsPanel.SetActive(false);
		controlPanel.SetActive(false);
	}

	public void onStartClick()
	{
        if (PlayerPrefs.GetInt("introDisplay") == 0)
            SceneManager.LoadScene("intro");
        else SceneManager.LoadScene("game");

    }

	public void OnExitClick()
	{
		Application.Quit();
	}

	public void OnApplyClick()
	{
		PlayerPrefs.SetFloat("soundVolume", AudioListener.volume);
		Debug.Log (PlayerPrefs.GetFloat("soundVolume"));
		DisActivePrefPanel();
	}

	void ActivePrefPanel()
	{
		prefsPanel.SetActive(true);
		creditsPanel.SetActive(false);
		controlPanel.SetActive(false);
	}

	void DisActivePrefPanel()
	{
		prefsPanel.SetActive(false);
	}

	public void OnClickCredits()
	{
		creditsPanel.SetActive(true);
		prefsPanel.SetActive(false);
		controlPanel.SetActive(false);
	}

	public void OnGamePadClick()
	{
		controlPanel.SetActive(true);
		creditsPanel.SetActive(false);
		prefsPanel.SetActive(false);
	}

	public void OnClickOkCredits()
	{
		creditsPanel.SetActive(false);
		controlPanel.SetActive(false);
	}	
}
