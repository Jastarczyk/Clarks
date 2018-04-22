using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Global
{
    class DifficultyManager : MonoBehaviour
    {
        /// <summary>
        /// How often difficulty should be increased [expressed in seconds]
        /// </summary>
        public float IncreasingPeriodicity;

        public delegate void DifficultyHandler();
        public static event DifficultyHandler DifficultyChanged;

        private const int maximumDiffucultyLevel = 10;

        private float difficultyTimer;
        private static int currentDifficultyLevel;

        private void Start()
        {
            difficultyTimer = default(float);
            currentDifficultyLevel = 1; //difficulty lvl started from 1 (not 0 like always)
        }

        private void Update()
        {
            if (!currentDifficultyLevel.Equals(maximumDiffucultyLevel))
            {
                difficultyTimer += Time.deltaTime;
            }

            if (difficultyTimer >= IncreasingPeriodicity)
            {
                IncreaseDifficultyLevel();
                difficultyTimer = default(float);
            }
        }

        public static int GetCurrentDiffucultyLevel()
        {
            return currentDifficultyLevel;
        }

        private void IncreaseDifficultyLevel(int amount = 1)
        {
            currentDifficultyLevel += amount;
            Debug.Log(currentDifficultyLevel);
            DifficultyChanged.Invoke();
        }
    }
}
