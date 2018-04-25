using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets._Scripts.Configuration.GameConfig;
using Assets._Scripts.Global;
using System;

public class MainMenuManager : MonoBehaviour 
{
    public GameObject prefsPanel;
	public GameObject creditsPanel;
	public GameObject controlPanel;

    public Slider LanguageSlider;

    private GameConfigManager gameConfigManager;
    private LocalizationManager localizationManager;
    private Text[] MenuTextItems;

    private void Awake()
    {
        gameConfigManager = new GameConfigManager();
        localizationManager = new LocalizationManager();
        MenuTextItems = GetComponentsInChildren<Text>();
    }

    private void Start () 
	{
		prefsPanel.SetActive(false);
		creditsPanel.SetActive(false);
		controlPanel.SetActive(false);

        SetMenuLocalizationText();
        SetLanguageSliderPossition();

    }

    private void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
		    DisactivePrefPanel();
			creditsPanel.SetActive(false);
			controlPanel.SetActive(false);
		}
	}


    private void OnPrefClick()
	{
		prefsPanel.SetActive(true);
		creditsPanel.SetActive(false);
		controlPanel.SetActive(false);
	}

    private void onStartClick()
	{
        if (PlayerPrefs.GetInt("introDisplay") == 0)
            SceneManager.LoadScene("intro");
        else SceneManager.LoadScene("game");

    }

    private void OnExitClick()
	{
		Application.Quit();
	}

    private void OnApplyClick()
	{
		PlayerPrefs.SetFloat("soundVolume", AudioListener.volume);
		Debug.Log (PlayerPrefs.GetFloat("soundVolume"));
		DisactivePrefPanel();
	}

	private void ActivePrefPanel()
	{
		prefsPanel.SetActive(true);
		creditsPanel.SetActive(false);
		controlPanel.SetActive(false);
	}

	private void DisactivePrefPanel()
	{
		prefsPanel.SetActive(false);
	}

    private void OnClickCredits()
	{
		creditsPanel.SetActive(true);
		prefsPanel.SetActive(false);
		controlPanel.SetActive(false);
	}

	private void OnGamePadClick()
	{
		controlPanel.SetActive(true);
		creditsPanel.SetActive(false);
		prefsPanel.SetActive(false);
	}

    private void OnClickOkCredits()
	{
		creditsPanel.SetActive(false);
		controlPanel.SetActive(false);
	}

    private void SetLanguageSliderPossition()
    {
        // TODO refactoring
        LanguageSlider.value = GameConfigManager.GetGameSettings().Language.Equals("English") ?  1 : default(float);
    }

    //TODO refactor it lately
    private void SetMenuLocalizationText()
    {
        try
        {
            MenuTextItems.Where(x => x.transform.name.Equals("LanguageTextLabel")).FirstOrDefault().text = localizationManager
                                                                                                            .GetLocalizationDictionary()
                                                                                                            ["LanguageTextLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("PolishLanguageLabel")).FirstOrDefault().text = localizationManager
                                                                                                             .GetLocalizationDictionary()
                                                                                                             ["PolishLanguageLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("SaveButtonText")).FirstOrDefault().text = localizationManager
                                                                                                        .GetLocalizationDictionary()
                                                                                                        ["SaveButtonText"];

            MenuTextItems.Where(x => x.transform.name.Equals("EnglishLanguageLabel")).FirstOrDefault().text = localizationManager
                                                                                                              .GetLocalizationDictionary()
                                                                                                              ["EnglishLanguageLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("SettingsMoveUpLabel")).FirstOrDefault().text = localizationManager
                                                                                                             .GetLocalizationDictionary()
                                                                                                             ["SettingsMoveUpLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("SettingsMoveDownLabel")).FirstOrDefault().text = localizationManager
                                                                                                               .GetLocalizationDictionary()
                                                                                                               ["SettingsMoveDownLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("SettingsMoveRightLabel")).FirstOrDefault().text = localizationManager
                                                                                                                .GetLocalizationDictionary()
                                                                                                                ["SettingsMoveRightLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("SettingsMoveLeftLabel")).FirstOrDefault().text = localizationManager
                                                                                                               .GetLocalizationDictionary()
                                                                                                               ["SettingsMoveLeftLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("SettingsShootLabel")).FirstOrDefault().text = localizationManager
                                                                                                            .GetLocalizationDictionary()
                                                                                                            ["SettingsShootLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("SettingsReloadLabel")).FirstOrDefault().text = localizationManager
                                                                                                             .GetLocalizationDictionary()
                                                                                                             ["SettingsReloadLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("SettingsFlashlightLabel")).FirstOrDefault().text = localizationManager
                                                                                                                 .GetLocalizationDictionary()
                                                                                                                 ["SettingsFlashlightLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("DeveloperLabel")).FirstOrDefault().text = localizationManager
                                                                                                        .GetLocalizationDictionary()
                                                                                                        ["DeveloperLabel"];

            MenuTextItems.Where(x => x.transform.name.Equals("TestersLabel")).FirstOrDefault().text = localizationManager
                                                                                                      .GetLocalizationDictionary()
                                                                                                      ["TestersLabel"];
        }
        catch (NullReferenceException ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
