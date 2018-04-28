using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets._Scripts.Configuration.GameConfig;
using Assets._Scripts.Configuration.GameConfig.Model;

[RequireComponent(typeof(IntroLanguageManager))]
public class IntroGUIManagment : MonoBehaviour
{
    public Text IntroTextPanel1;
    public GameObject ContinueButton;
    public GameObject StartButton;

    public Toggle IntroAskToggle;

    public delegate void ContinueButtonClickHandler(string itemName);
    public static event ContinueButtonClickHandler OnContinueButtonClick;

    private void Start()
    {
        ContinueButton.SetActive(true);
        StartButton.SetActive(false);
    }

    public void ContinueButton_OnClick()
    {
        OnContinueButtonClick.Invoke("IntroPage2Label");
        ContinueButton.SetActive(false);
        StartButton.SetActive(true);
    }

    public void StartButton_OnClick()
    {
        SceneManager.LoadScene("Level01");
        //TODO find out how to not override gamesettings because rest of values are reseted if i implement this one :"
        GameConfigManager.SaveGameSetting(new GameSettings() { SkipIntro = IntroAskToggle.isOn ? "1" : "0" });
    }
}
