using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Enemy
{
    [RequireComponent(typeof(AudioSource))]

    class EnemySoundManagement : MonoBehaviour
    {
        public AudioClip[] StandardSounds;
        public AudioClip[] AttackSounds;
        public AudioClip[] DeathSounds;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        //TODO rework
        public void PlayRandomStandardSound()
        {
            int randomClip = UnityEngine.Random.Range(0, StandardSounds.Length);
            audioSource.clip = StandardSounds[randomClip];
            audioSource.Play();
        }

        public void PlayRandomAttackSound()
        {
            int randomClip = UnityEngine.Random.Range(0, AttackSounds.Length);
            audioSource.clip = AttackSounds[randomClip];
            audioSource.Play();
        }

        public void PlayRandomDeathSound()
        {
            int randomClip = UnityEngine.Random.Range(0, DeathSounds.Length);
            audioSource.clip = DeathSounds[randomClip];
            audioSource.Play();
        }

    }
}
