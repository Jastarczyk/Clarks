﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Assets._Scripts.Enemy;
using Assets._Scripts.Global;

public class ZombieController : MonoBehaviour
{
    // should not be in a zombie controller, this kind of object requests extracted model
    [SerializeField] private int ZombieAttackPower = 1;

    public float InitialMovementSpeed = 2f;

    //define zombie movement speed increasing by time
    private const float deltaSpeed = 0.1f;
    private const float maximumSpeed = 6f;

    float damageCooldown = 2f;
    float hitTimer;

    private PlayerController playerController;
    private NavMeshAgent navMeshAgent;
    private ScoreManager scoring;
    private float IncreaseSpeedTimePeroid = 1f;

    private EnemySoundManagement soundManager;
    private EnemyHealthManagement enemyHealthManagement;
    private ObjectDestroyManager objectDestoryManager;

    private CapsuleCollider zombieCollider;
    private EnemyAnimationManager zombieAnimator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        scoring = GameObject.FindGameObjectWithTag("GlobalScriptHolder").GetComponent<ScoreManager>();

        soundManager = GetComponent<EnemySoundManagement>();
        enemyHealthManagement = GetComponent<EnemyHealthManagement>();

        zombieCollider = GetComponent<CapsuleCollider>();
        zombieAnimator = GetComponent<EnemyAnimationManager>();
    }

    private void Start()
    {
        navMeshAgent.speed = InitialMovementSpeed;
        InvokeRepeating("IncreseZombieMovementSpeed", IncreaseSpeedTimePeroid, IncreaseSpeedTimePeroid);
    }

    private void Update()
    {
        //when zombie dies
        if (!enemyHealthManagement.IsAlive)
        {
            navMeshAgent.SetDestination(this.transform.position);
            return;
        }

        navMeshAgent.SetDestination(playerController.transform.position);
        hitTimer += Time.deltaTime;
    }

    private void IncreseZombieMovementSpeed()
    {
        if (navMeshAgent == null)
        {
            return;
        }

        if (navMeshAgent.speed <= maximumSpeed)
        {
            navMeshAgent.speed += deltaSpeed;
        }
    }

    void OnTriggerEnter(Collider hittedCollider)
    {
        if (hittedCollider.CompareTag("Bullet"))
        {
            ZombieDeath();
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (hitTimer > damageCooldown)
        {
            objectDestoryManager = collider.gameObject.GetComponent<ObjectDestroyManager>();

            if (objectDestoryManager == null)
            {
                Debug.LogError("Trying to access empty collider, check it please: " 
                    + collider.name + " " + collider.gameObject.transform.parent);

                return;
            }

            objectDestoryManager.DealDamage(ZombieAttackPower);
            zombieAnimator.PlayAttackAnimation();
            soundManager.PlayRandomSoundOfType(AudioClipsTypes.Attack);
            hitTimer = 0;
        }
    }

    private void ZombieDeath()
    {
        zombieCollider.enabled = false;
        enemyHealthManagement.Kill();

        soundManager.PlayRandomSoundOfType(AudioClipsTypes.Death);
        zombieAnimator.PlayDeathAnimation();

        Destroy(this.gameObject, 3f);
        scoring.Addscore(10);
    }
}
