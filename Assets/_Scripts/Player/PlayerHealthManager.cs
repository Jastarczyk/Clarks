using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Player
{
    class PlayerHealthManager : PlayerModel
    {
        public delegate void PlayerDeathHandler();
        public static event PlayerDeathHandler OnPlayerDeath;

        private void Start()
        {
            MaximumHealth = 1f;
            CurrentHealth = MaximumHealth;
            IsDead = false;
        }

        private void TakeDamage(int damageValue)
        {
            if (!IsDead)
            {
                CurrentHealth -= damageValue;
                IsDead = CheckIfPlayerIsDead();

                if (IsDead)
                {
                    OnPlayerDeath.Invoke();
                }
            }
            else
            {
                Debug.Log("Player is already dead - can't take more damage.");
            }
        }

        private bool CheckIfPlayerIsDead()
        {
            return CurrentHealth <= 0;
        }

        private void OnTriggerEnter(Collider encounteredCollider)
        {
            if (encounteredCollider.CompareTag("Target") && !godMode)
            {
                TakeDamage(1);
            }
        }
    }
}
