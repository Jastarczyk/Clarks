using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour
{
    private GamePause()
    { }

    public static bool Pause { get; private set; }

	public static void PauseOn()
	{
		Time.timeScale = 0f;
        Pause = true;
	}

	public static void PauseOff()
	{
		Time.timeScale = 1f;
        Pause = false;
	}

	void Awake()
	{
		Time.timeScale = 1f;
	}
}
