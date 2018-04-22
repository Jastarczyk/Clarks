using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.AttachedToObjects.Weapons
{
    public abstract class Firearm : MonoBehaviour
    {
        public float ShootCooldownTime;

        public float BulletInsertTime;

        public float MaximumMagazineCapacity;

        public AudioSource ShootSound;

        public AudioSource ReloadSound;
    }
}
