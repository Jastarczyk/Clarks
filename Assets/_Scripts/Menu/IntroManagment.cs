using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManagment : MonoBehaviour 
{

	public GameObject intro1Text;
	public GameObject intro2Text;
	public GameObject continueButtonGO;
	public GameObject continueButton2GO;

	public Button continueButton;
	public Button continueButton2;

	void Awake () 
	{
		intro1Text.SetActive(true);
		intro2Text.SetActive(false);
		continueButton2GO.SetActive(false);
	}

	public void OnFirstContinueClick()
	{
		intro1Text.SetActive(false);
		intro2Text.SetActive(true);
		continueButtonGO.SetActive(false);
		continueButton2GO.SetActive(true);
	}

	public void OnSecondContinueClick()
	{
		//Application.LoadLevel("game");
        SceneManager.LoadScene("game");
	}

	public void dontDisplayIntroAgain()
	{
		PlayerPrefs.SetInt("introDisplay", 1);
	}
}
