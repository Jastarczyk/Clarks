using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets._Scripts.Configuration.GameConfig;
using Assets._Scripts.Global;
using System;
using Assets._Scripts.Configuration.GameConfig.Model;
using Assets._Scripts.Configuration.Localization;
using Assets._Scripts.Configuration;

public class MainMenuGUIManager : MonoBehaviour
{
    public GameObject controlPanel;
    public GameObject creditsPanel;
    public GameObject gameSettingsPanel;

    public Slider LanguageSlider;
    public Slider VolumeSlider;

    public delegate void GameLanguageChanged(Languages language);
    public static event GameLanguageChanged OnLanguageSliderValueChanged;

    private Text[] menuTextItems;

    private void Awake()
    {
        menuTextItems = GameObject.FindGameObjectWithTag("ActiveGUI").GetComponentsInChildren<Text>();
    }

    private void Start()
    {
        SetAllPanelsToInactive();
        SetSceneTranslation();
        SetLanguageSliderStartingPossition();
        SetSoundSliderPossition();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SetAllPanelsToInactive();
        }
    }

    #region Pseudo-events

    public void OnClick_GameSettings()
    {
        gameSettingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        controlPanel.SetActive(false);
    }

    public void OnClick_Credits()
    {
        creditsPanel.SetActive(true);
        gameSettingsPanel.SetActive(false);
        controlPanel.SetActive(false);
    }

    public void OnClick_ControlPanel()
    {
        creditsPanel.SetActive(false);
        gameSettingsPanel.SetActive(false);
        controlPanel.SetActive(true);
    }

    public void OnClick_CreditsOKButton()
    {
        creditsPanel.SetActive(false);
        controlPanel.SetActive(false);
    }

    public void OnClick_GameSettingsApplyButton()
    {
        GameSettings gameSettings = new GameSettings()
        {
            Language = LanguageSlider.value == 0 ? Languages.Polish.ToString() : Languages.English.ToString(),
            SoundVolume = VolumeSlider.value.ToString(),
        };

        TranslationManager.SetCurrentGameLanguage(gameSettings.Language);
        GameConfigManager.SaveGameSetting(gameSettings);
        SetSceneTranslation();

        SetAllPanelsToInactive();
    }

    public void OnClick_ControlPanelOKButton()
    {
        SetAllPanelsToInactive();
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene(String.Format("{0}", PlayerPrefs.GetString(Conf.PlayerPrefIntroSkipName).Equals("0") ? "Intro" : "Level01"));
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }

    public void OnValueChange_VolumeSlider()
    {
        menuTextItems.Where(x => x.transform.name.Equals("SoundVolumeLabel")).FirstOrDefault().text = VolumeSlider.value.ToString();
        AudioListener.volume = VolumeSlider.value / 100f;
    }

    public void OnValueChange_LanguageSlider()
    {
        OnLanguageSliderValueChanged.Invoke(LanguageSlider.value == 1 ? Languages.English : Languages.Polish);
    }

    #endregion

    private void SetAllPanelsToInactive()
    {
        gameSettingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        controlPanel.SetActive(false);
    }

    private void SetLanguageSliderStartingPossition()
    {
        //should rework it when it will be more than 2 languages implemented
        LanguageSlider.value = GameConfigManager.GetGameSettings().Language.Equals(Languages.English.ToString()) ? 1 : default(float);
    }

    private void SetSoundSliderPossition()
    {
        int parsedVolume = default(int);

        if (Int32.TryParse(GameConfigManager.GetGameSettings().SoundVolume, out parsedVolume))
        {
            VolumeSlider.value = parsedVolume;
            menuTextItems.Where(x => x.transform.name.Equals("SoundVolumeLabel")).FirstOrDefault().text = VolumeSlider.value.ToString();
        }
    }

    private void SetSceneTranslation()
    {
        foreach (Text textLabel in menuTextItems)
        {
            if (TranslationManager.GetLocalizationDictionary().ContainsKey(textLabel.name))
            {
                textLabel.text = TranslationManager.GetLocalizationDictionary()[textLabel.name];
            }
        }
    }
}
