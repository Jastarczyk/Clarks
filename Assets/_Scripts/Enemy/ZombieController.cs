using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Assets._Scripts.Enemy;
using Assets._Scripts.Global;

public class ZombieController : MonoBehaviour
{
    public float InitialMovementSpeed = 2f;

    //define zombie movement speed increasing by time
    private const float deltaSpeed = 0.1f;
    private const float maximumSpeed = 6f;

    float damageCooldown = 2f;
    float hitTimer;

    private PlayerController playerController;
    private NavMeshAgent navMeshAgent;
    private Scoring scoring;
    private float IncreaseSpeedTimePeroid = 1f;

    private EnemySoundManagement soundManager;
    private EnemyHealthManagement healthManagement;

    private CapsuleCollider zombieCollider;
    private EnemyAnimationManager zombieAnimator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        scoring = GameObject.Find("ScoreDisplay").GetComponent<Scoring>();

        soundManager = GetComponent<EnemySoundManagement>();
        healthManagement = GetComponent<EnemyHealthManagement>();

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
        if (!healthManagement.IsAlive)
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

    void OnTriggerStay()
    {
        if (hitTimer > damageCooldown)
        {
            zombieAnimator.PlayAttackAnimation();
            soundManager.PlayRandomAttackSound();
            hitTimer = 0;
        }
    }

    private void ZombieDeath()
    {
        zombieCollider.enabled = false;
        healthManagement.Kill();

        soundManager.PlayRandomDeathSound();
        zombieAnimator.PlayDeathAnimation();

        Destroy(this.gameObject, 3f);
        scoring.Addscore(10);
    }
}
