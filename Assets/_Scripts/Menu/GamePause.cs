using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {

	bool pause;
	
	public bool _pause
	{
		get { return pause; }
	}

	public void PauseOn()
	{
		Time.timeScale = 0f;
		pause = true;
	}

	public void PauseOff()
	{
		Time.timeScale = 1f;
		pause = false;
	}

	void Awake()
	{
		Time.timeScale = 1f;
	}
}
