using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Player
{
    class PlayerModel : MonoBehaviour
    {
        public float MaximumHealth { get; protected set; }

        public float CurrentHealth { get; protected set; }

        public bool IsDead { get; protected set; }

        [SerializeField]
        protected bool godMode;   //god mode just for debug
    }
}
