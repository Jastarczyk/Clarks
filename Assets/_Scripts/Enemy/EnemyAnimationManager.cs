using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Enemy
{
    [RequireComponent(typeof(Animator))]
    class EnemyAnimationManager : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {

        }

        //Learn how to deal with animation because this is so bad :( TODO
        public void PlayDeathAnimation()
        {
            animator.Play("death03");
        }

        public void PlayAttackAnimation()
        {
            animator.Play("attack01");
        }

    }
}
