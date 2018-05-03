using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets._Scripts.Player;
using Assets._Scripts.Global;

public class InGameMenuManager : MonoBehaviour
{
    #region Shown in Inspector

    [SerializeField] private Button PlayButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private GameObject InGameMenu;
    [SerializeField] private GameObject PlayerDeathPanel;
    [SerializeField] private GameObject MainGUI;

    [SerializeField] private Text ScoreValueTextLabel;
    [SerializeField] private Text CountDownTextLabel;
    [SerializeField] private Text BestScoreValueText;
    [SerializeField] private Text EarnedScoreValueText;

    #endregion

    private PlayerHealthManager playerHealthManager;
    private Text[] menuTextItems;
    private ScoreManager scoring;

    private void Awake()
    {
        menuTextItems = GameObject.FindGameObjectWithTag("ActiveGUI").GetComponentsInChildren<Text>();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
        scoring = GetComponent<ScoreManager>();
    }

    private void Start()
    {
        PlayerHealthManager.OnPlayerDeath += PlayerHealthManager_OnPlayerDeath;
        GlobalTimer.OnCountDownSecondValueChange += GlobalTimer_OnCountDownSecondValueChange;

        SetSceneTranslation();
        SetStartingGUIBegaviour();

        CountDownTextLabel.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!InGameMenu.activeInHierarchy && !playerHealthManager.IsDead)
            {
                ActiveGameMenu();
            }
            else if (InGameMenu.activeInHierarchy && !playerHealthManager.IsDead)
            {
                DisactiveGameMenu();
            }
        }
    }

    //On player's death event rise
    private void PlayerHealthManager_OnPlayerDeath()
    {
        DisplayGameOverMenu();
    }

    private void GlobalTimer_OnCountDownSecondValueChange()
    {
        CountDownTextLabel.text = GlobalTimer.SecondLeftToStart.ToString();

        if (GlobalTimer.SecondLeftToStart == 0)
        {
            CountDownTextLabel.text = TranslationManager.GetLocalizationDictionary()["CountdownEndInfoTextLabel"];
            Invoke("DisableCountDownTextLabel", 1f);
        }
    }

    private void DisableCountDownTextLabel()
    {
        CountDownTextLabel.gameObject.SetActive(false);
    }

    private void DisplayGameOverMenu()
    {
        ActiveGameMenu();
        PlayerDeathPanel.SetActive(true);
        MainGUI.SetActive(false);
        DisableReturnButton();
        DisplayUserScores();
    }

    #region MenuInteractions

    public void ReturnButton_OnClick()
    {
        DisactiveGameMenu();
    }

    public void RestartButton_OnClick()
    {
        GamePause.PauseOff();
        CancelInvoke();
        SceneManager.LoadScene("Level01");
    }

    public void ExitButton_OnClick()
    {
        GamePause.PauseOff();
        SceneManager.LoadScene("MainMenu");
    }

    public void ActiveGameMenu()
    {
        InGameMenu.SetActive(true);
        GamePause.PauseOn();
    }

    private void DisableReturnButton()
    {
        PlayButton.image.color = new Color(0.2F, 0.3F, 0.4F, 0.5F);
        PlayButton.interactable = false;
    }

    private void DisactiveGameMenu()
    {
        InGameMenu.SetActive(false);
        GamePause.PauseOff();
    }

    #endregion

    private void SetStartingGUIBegaviour()
    {
        InGameMenu.SetActive(false);
        PlayerDeathPanel.SetActive(false);
    }

    private void DisplayUserScores()
    {
        EarnedScoreValueText.text = scoring.CurrentScore.ToString();

        if (scoring.CurrentScore > PlayerPrefs.GetInt("highestScore"))
        {
            PlayerPrefs.SetInt("highestScore", scoring.CurrentScore);
        }

        BestScoreValueText.text = PlayerPrefs.GetInt("highestScore").ToString();
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

    private void OnDestroy()
    {
        GlobalTimer.OnCountDownSecondValueChange -= GlobalTimer_OnCountDownSecondValueChange;
    }
}