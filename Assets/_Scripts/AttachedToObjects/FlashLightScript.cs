using UnityEngine;
using System.Collections;

public class FlashLightScript : MonoBehaviour 
{
    public float OnIntensity = 5f;

    private float OffIntensity = 0f;
    private Light emittedLight;
    private bool IsTurnedOn;

    private void Awake()
    {
        emittedLight = GetComponentInChildren<Light>();
    }

    private void Start()
	{
        //to conclude if flashlight is on or off on start
        IsTurnedOn = emittedLight.intensity > 0 ? true
                                                : false;
        emittedLight.intensity = OnIntensity;
    }

    public void SwitchLight()
    {
        emittedLight.intensity = IsTurnedOn ? OffIntensity : OnIntensity;
        IsTurnedOn = !IsTurnedOn;
    }
}
