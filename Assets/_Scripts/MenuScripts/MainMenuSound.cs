using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuSound : MonoBehaviour
{
    public AudioSource MainMenuAudioSource;

    private void Awake()
    {
        MainMenuAudioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    void Start ()
    {
        MainMenuAudioSource.Play();
	}
}
