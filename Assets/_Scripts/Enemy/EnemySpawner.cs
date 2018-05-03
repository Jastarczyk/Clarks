using UnityEngine;
using System.Collections;
using Assets._Scripts.Global;

public class EnemySpawner : MonoBehaviour
{
	public GameObject EnemyPrefab;
	public GameObject[] EnemySpawners;
    public float SpawnIntervalTime;
    public float SpawnDecreasingValue;

    private Transform playerTransform;
	private float spawningTimer;
    private float minDistanceSpawnFromPlayer = 5f;   

    public float GetSpawningTimer()
    {
        return spawningTimer;
    }

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        spawningTimer = default(float);

        if (SpawnIntervalTime == default(float))
        {
            Debug.LogError("Please set Spawn Intervals.");
        }

        DifficultyManager.DifficultyChanged += DifficultyManager_DifficultyChanged;
    }

    private void Update()
	{
        spawningTimer += Time.deltaTime;

        if (spawningTimer > SpawnIntervalTime && GlobalTimer.GameStarted)
        {
            SpawnZombieAtRandomPlace();
            spawningTimer = default(float);
        }
	}

    private void DifficultyManager_DifficultyChanged()
    {
        DecreaseSpawningTime();
    }

    private void SpawnZombieAtRandomPlace()
	{
        int spawningPointIndex = Random.Range(0, EnemySpawners.Length);
        float distanceToPlayer = Vector3.Distance(EnemySpawners[spawningPointIndex].transform.position, playerTransform.position);

        // it was implemented to prevent spawning the enemy a front/on the player
        while (minDistanceSpawnFromPlayer > distanceToPlayer)
        {
            spawningPointIndex = Random.Range(0, EnemySpawners.Length);
            distanceToPlayer = Vector3.Distance(EnemySpawners[spawningPointIndex].transform.position, playerTransform.position);
            Debug.Log("Recalculate respawin point");

            if (minDistanceSpawnFromPlayer < distanceToPlayer)
            {
                break;
            }
        }

        Instantiate(EnemyPrefab, EnemySpawners[spawningPointIndex].transform.position, Quaternion.LookRotation(playerTransform.position));
    }

    private void DecreaseSpawningTime()
    {
        float spawningTimeLimit = 1f;

        if (SpawnIntervalTime > spawningTimeLimit)
        {
            SpawnIntervalTime -= SpawnDecreasingValue;
        }
    }
}
