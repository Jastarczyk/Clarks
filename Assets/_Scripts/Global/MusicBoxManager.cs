using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioClip))]
public class MusicBoxManager : MonoBehaviour        
{
	public AudioClip MainTheme;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = MainTheme;
    }

    void Start()
    {
        source.Play();
    }
}
