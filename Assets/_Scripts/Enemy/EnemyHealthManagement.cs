using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Enemy
{
    [RequireComponent(typeof(Transform))]

    class EnemyHealthManagement : EnemyHealth
    {
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
