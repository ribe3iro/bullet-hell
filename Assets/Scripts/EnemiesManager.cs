using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] EdgeCollider2D unspawner;
    [SerializeField] GameObject player;

    EnemySpawnInfo[] enemiesSpawnInfo;

    int updateCalls = 0;

    void Start()
    {
        enemiesSpawnInfo = new EnemySpawnInfo[]{
            new EnemySpawnInfo("Hexagono", 100, 3f, 10),
            new EnemySpawnInfo("Quadrado", 300, 7.5f, 4, 500),
            new EnemySpawnInfo("Triangulo", 400, 3f, 2, 1000),
        };
    }

    void FixedUpdate()
    {
        updateCalls++;
        for (int i = 0; i < enemiesSpawnInfo.Length; i++)
        {
            EnemySpawnInfo spawnInfo = enemiesSpawnInfo[i];

            if (updateCalls >= spawnInfo.minIntervalToSpawn && updateCalls % spawnInfo.spawnInterval == 0)
            {
                Vector2 spawnPosition = this.transform.position;
                spawnPosition.x += Random.Range(-6f, 6f);

                EnemyController.GenerateEnemy(spawnInfo, spawnPosition, this.unspawner, this.player);
            }
        }
    }
}

public class EnemySpawnInfo : MonoBehaviour
{
    public string shape;
    public int spawnInterval;
    public float velocityMag;
    public int spawnsUntilIncreaseDifficulty;
    public int minIntervalToSpawn;

    public int spawns;

    public static int MIN_SPAWN_INTERVAL = 50;

    public EnemySpawnInfo(string shape, int spawnInterval, float velocityMag, int spawnsUntilIncreaseDifficulty, int minIntervalToSpawn = 0)
    {
        this.shape = shape;
        this.spawnInterval = spawnInterval;
        this.velocityMag = velocityMag;
        this.spawnsUntilIncreaseDifficulty = spawnsUntilIncreaseDifficulty;
        this.minIntervalToSpawn = minIntervalToSpawn;

        this.spawns = 0;
    }
}
