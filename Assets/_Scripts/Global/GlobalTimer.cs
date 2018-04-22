using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    public static float Timer { get; private set; }

	void Start ()
    {
        Timer = 0f;
	}

	void Update ()
    {
        Timer += Time.deltaTime;
	}
}
