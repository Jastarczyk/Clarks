using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Enemy
{
    internal enum AudioClipsTypes
    {
        Standard,
        Attack,
        Death
    }

    [RequireComponent(typeof(AudioSource))]

    class EnemySoundManagement : MonoBehaviour
    {
        public AudioClip[] StandardSounds;
        public AudioClip[] AttackSounds;
        public AudioClip[] DeathSounds;

        private AudioClip[] chosenCollection;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayRandomSoundOfType(AudioClipsTypes type)
        {
            switch (type)
            {
                case AudioClipsTypes.Standard:
                    chosenCollection = StandardSounds;
                    break;

                case AudioClipsTypes.Attack:
                    chosenCollection = AttackSounds;
                    break;

                case AudioClipsTypes.Death:
                    chosenCollection = DeathSounds;
                    break;
            }

            int randomClip = UnityEngine.Random.Range(0, chosenCollection.Length);
            audioSource.clip = chosenCollection[randomClip];
            audioSource.Play();
        }
    }
}
