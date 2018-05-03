using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    public static float Timer { get; private set; }
    public static bool GameStarted { get; private set; }
    public static float SecondLeftToStart { get; private set; }

    public float CountDownTime;

    public delegate void CountDownSecondChangeHandler();
    public static event CountDownSecondChangeHandler OnCountDownSecondValueChange;

    private void Start()
    {
        Timer = 0f;
        SecondLeftToStart = CountDownTime;
        InitGameStartCountDown();
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (SecondLeftToStart <= 0f && !GameStarted)
        {
            CancelInvoke("DecrementCountDownTimer");
            GameStarted = true;
        }
    }

    private void InitGameStartCountDown()
    {
        InvokeRepeating("DecrementCountDownTimer", 0f, 1f);
    }

    private void DecrementCountDownTimer()
    {
        SecondLeftToStart--;
        OnCountDownSecondValueChange.Invoke();
    }
}
