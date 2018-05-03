using UnityEngine;

public class AudioManager : MonoBehaviour        
{
	public AudioClip MainTheme;
    private AudioSource mainAudioSource;
    private AudioSource secondAudioSource;

    private void Awake()
    {
        mainAudioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        secondAudioSource = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        mainAudioSource.clip = MainTheme;
    }

    void Start()
    {
        mainAudioSource.Play();
        GlobalTimer.OnCountDownSecondValueChange += GlobalTimer_OnCountDownSecondValueChange;
    }

    private void GlobalTimer_OnCountDownSecondValueChange()
    {
        if (GlobalTimer.SecondLeftToStart == 0)
        {
            secondAudioSource.clip = GetAudioClipByPath("Sounds/bells/churchbell1");
            secondAudioSource.Play();
        }
    }

    private AudioClip GetAudioClipByPath(string path)
    {
        object loadedResource = Resources.Load(path);

        if (loadedResource == null)
        {
            Debug.LogError("Missing Resource at " + path);
        }

        return loadedResource as AudioClip;
    }

    private void OnDestroy()
    {
        GlobalTimer.OnCountDownSecondValueChange -= GlobalTimer_OnCountDownSecondValueChange;
    }
}
