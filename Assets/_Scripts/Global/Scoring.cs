using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoring : MonoBehaviour 
{
	public Text scoreText;
	InGameMenuManager inGameMenu;
	Text scoreValue;
	Text multiplerText;

	int currentScore = 0;
	float comboTimer;
	float comboTimeLimit = 1.5f;
	int multipler = 1;
	int multiplerLimit = 10;
	
	void Update()
	{
		comboTimer += Time.deltaTime;

		if (multipler > 1 && comboTimer < comboTimeLimit)
			multiplerText.text = "x" + multipler.ToString() + "!";
		else multiplerText.text = null;
	}

	public int _currentScore
	{
		get { return currentScore; }
	}
		
	void Start()
	{
		inGameMenu = GameObject.Find ("Canvas").GetComponent<InGameMenuManager>();
		scoreValue = GameObject.Find ("scoreValue").GetComponent<Text>();
		multiplerText = GameObject.Find ("Multipler").GetComponent<Text>();

		scoreText.text = inGameMenu.scoreDisplay.text;
		scoreValue.text = currentScore.ToString();
	}

	public void Addscore(int score)
	{
		if(comboTimer < comboTimeLimit)
		{
			if (multipler <= multiplerLimit)
			{
				score *= multipler;
				multipler++;
			}
			else multipler = multiplerLimit;
		}
		else multipler = 1;

		currentScore += score;
		scoreText.text = inGameMenu.scoreDisplay.text;
		scoreValue.text = currentScore.ToString();
		comboTimer = 0f;
	}
}
