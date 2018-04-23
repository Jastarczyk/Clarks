using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour
{
    public bool Pause { get; private set; }

	public void PauseOn()
	{
		Time.timeScale = 0f;
        Pause = true;
	}

	public void PauseOff()
	{
		Time.timeScale = 1f;
        Pause = false;
	}

	void Awake()
	{
		Time.timeScale = 1f;
	}
}
