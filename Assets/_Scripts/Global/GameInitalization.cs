using Assets._Scripts.Configuration;
using Assets._Scripts.Configuration.GameConfig;
using Assets._Scripts.Global;
using UnityEngine;

[RequireComponent(typeof(TranslationManager))]
public class GameInitalization : MonoBehaviour
{
    private void Awake ()
    {
        SetAudioVolume();
    }

    private void SetAudioVolume()
    {
        AudioListener.volume =  PlayerPrefs.GetFloat(Conf.PlayerPrefSoundVolumeName) / 100f;
    }
}
