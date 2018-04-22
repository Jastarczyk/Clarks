using UnityEngine;

public class BlinkingLight : MonoBehaviour 
{
	private Light blinkingLight;
	private float timer;

	void Start () 
	{
        blinkingLight = GetComponent<Light>();
	}

	void Update () 
	{
		if(timer > 0.1f)
		{
            blinkingLight.intensity = Random.Range(0,2);
			timer = 0f;
		}

		timer += Time.deltaTime;
	}
}
