using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets._Scripts.Player;

public class InGameMenuManager : MonoBehaviour 
{
	GamePause gamePause;
    private PlayerHealthManager playerHealth;
	Scoring scoring;
	EnemySpawner zombieSpawner;

	public AudioClip[] bells;
	AudioSource bellSound;

	public Button playButton;
	public Button returnButton;
	public Button exitButton;

	public GameObject playButtonGO;
	public GameObject inGameMenu;
	public GameObject deadPlayerGO;
	public GameObject gui;
	public GameObject countDownGO;

	Text scoreText;
	Text bestScore;
	Text bestScoreText;

	bool menuOn = false;
	bool saved = false;
	bool countdowned = false;

	// language Texts

	public Text returnText;
	public Text restartText;
	public Text exitText;
	public Text titleClarkDead;
	public Text deadScoreText; 
	public Text gameMenuText;
	public Text scoreDisplay;
	public Text countDown;

	public TextMesh doorHintText;

	void Awake()
	{
		doorHintText = GameObject.Find ("DoorHintText").GetComponent<TextMesh>();

        bestScore = GameObject.Find("bestscore").GetComponent<Text>();
        scoreText = GameObject.Find("score").GetComponent<Text>();
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<Text>();
        bestScoreText = GameObject.Find("text:bestscore").GetComponent<Text>();
        zombieSpawner = GameObject.Find("Spawners").GetComponent<EnemySpawner>();
        countDown = GameObject.Find("Countdown").GetComponent<Text>();
        gamePause = GameObject.Find("GlobalScriptsObject").GetComponent<GamePause>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
        scoring = GameObject.Find("ScoreDisplay").GetComponent<Scoring>();
        bellSound = GetComponent<AudioSource>();

    }

	void Start () 
	{	
		inGameMenu.SetActive(false);
		deadPlayerGO.SetActive(false);
		LanguageChange();
    }

	void Update () 
	{
		CountDown();

		if(playerHealth.IsDead)
		{
			ActiveMenu();
			playButton.image.color = new Color(0.2F, 0.3F, 0.4F, 0.5F);
			deadPlayerGO.SetActive(true);
			scoreText.text = scoring._currentScore.ToString();
			gui.SetActive(false);

			if(!saved)
			{

				if(scoring._currentScore > PlayerPrefs.GetInt("highestScore"))
				{
					PlayerPrefs.SetInt("highestScore", scoring._currentScore);
				}
				bestScore.text =  PlayerPrefs.GetInt("highestScore").ToString();
				Debug.Log ( PlayerPrefs.GetInt("highestScore"));
				saved = true;
			}

		}

		if(Input.GetKeyDown(KeyCode.Escape) && !menuOn && !playerHealth.IsDead)
			ActiveMenu();

		else if(Input.GetKeyDown(KeyCode.Escape) && menuOn && !playerHealth.IsDead)
			DisactiveMenu();
	}

	public void ActiveMenu()
	{
		inGameMenu.SetActive(true);
		menuOn = true;
		gamePause.PauseOn();
	}

	public void DisactiveMenu()
	{
		inGameMenu.SetActive(false);
		menuOn = false;
		gamePause.PauseOff();
	}


	public void ReturnToGame()
	{
		DisactiveMenu();
	}

	public void RestartGame()
	{
		gamePause.PauseOff();
        SceneManager.LoadScene("game");
	}

	public void ExitGame()
	{
		gamePause.PauseOff();
        SceneManager.LoadScene(0);
	}

	void LanguageChange()
	{

		if(PlayerPrefs.GetString("gameLanguage") == "Polish")
		{
			returnText.text = "Powrót";
			restartText.text = "Powtórz";
			exitText.text = "Wyjście";
			titleClarkDead.text = "Clark (w końcu) zginął";
			deadScoreText.text = "Zdobyte punkty:";
			gameMenuText.text = "Menu gry";
			scoreText.text = "Wynik: ";
			bestScoreText.text = "Najlepszy wynik:";
			scoreDisplay.text = "Wynik: ";
			doorHintText.text = "Naciśnij 'F' aby otworzyć";
		}
		else 
		{
			returnText.text = "Return";
			restartText.text = "Restart";
			exitText.text = "Exit";
			titleClarkDead.text = "Clark is (finally) dead";
			deadScoreText.text = "Earned score: ";
			gameMenuText.text = "Game menu";
			scoreText.text = "Score: ";
			bestScoreText.text = "Best score:";
			scoreDisplay.text = "Score: ";
			doorHintText.text = "Press 'F' to open";
		}
	}

	void CountDown()
	{
		if(!countdowned)
		{
			int buffor = (int)GlobalTimer.Timer;

			switch(buffor)
			{
			case 2: 
			{ 
				countDown.text = "3"; 
			}
				break;
			case 3: 
			{ 
				countDown.text = "2"; 
			}
				break;
			case 4: 
			{ 
				countDown.text = "1"; 
			}
				break;
			case 5:
			{ 
				if(PlayerPrefs.GetString("gameLanguage") == "Polish")
				    countDown.text = "start";
				else countDown.text = "begin";
				    bellSound.clip = bells[0]; 
				bellSound.Play();
			}
				break;

				default: countDown.text = null;
				break;
			}

			if(GlobalTimer.Timer >= 5f)  
			{
				countdowned = true;
				Destroy(countDownGO, 2f);
			}
		}
	}
}
