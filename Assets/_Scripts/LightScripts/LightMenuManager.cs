using UnityEngine;
using System.Collections;

public class LightMenuManager : MonoBehaviour {

	Light topLight;
	float timer;

	void Start () 
	{
		topLight = GetComponent<Light>();
	}
	

	void Update () 
	{
		if(timer > 0.1f)
		{
			topLight.intensity = Random.Range (0, 2);
			timer = 0f;
		}

		timer += Time.deltaTime;
	}
}
