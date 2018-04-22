using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Enemy
{
    [RequireComponent(typeof(Transform))]

    class EnemyHealthManagement : MonoBehaviour
    {
        public bool IsAlive { get; private set; }

        [SerializeField]
        public float MaximumHealth { get; private set; }

        public float CurrentHealth { get; private set; }

        private Transform enemyTransform;

        private void Awake()
        {
            enemyTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            IsAlive = true;
            CurrentHealth = MaximumHealth;
        }

        public void Kill()
        {
            if (IsAlive == true)
            {
                IsAlive = false;
            }
            else
            {
                Debug.Log(String.Format("Enemy is already dead: {0}", transform.name));
            }
        }

    }
}
