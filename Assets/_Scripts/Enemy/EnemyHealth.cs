using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public bool IsAlive { get; protected set; }

        [SerializeField]
        public float MaximumHealth { get; protected set; }

        public float CurrentHealth { get; protected set; }
    }
}
