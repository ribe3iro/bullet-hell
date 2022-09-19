using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] EdgeCollider2D unspawner;

    EnemySpawnInfo[] enemiesSpawnInfo;

    int updateCalls = 0;

    void Start()
    {
        enemiesSpawnInfo = new EnemySpawnInfo[]{
            new EnemySpawnInfo("Triangulo", 100, 3f, 10),
            new EnemySpawnInfo("Quadrado", 500, 7.5f, 4),
        };
    }

    void FixedUpdate()
    {
        updateCalls++;
        for (int i = 0; i < enemiesSpawnInfo.Length; i++)
        {
            EnemySpawnInfo spawnInfo = enemiesSpawnInfo[i];

            if (updateCalls % spawnInfo.spawnInterval == 0)
            {
                Vector2 pos = this.transform.position;
                pos.x += Random.Range(-6f, 6f);

                Spawn(pos, spawnInfo);
            }
        }
    }

    private GameObject Spawn(Vector2 position, EnemySpawnInfo spawnInfo)
    {
        spawnInfo.spawns++;

        GameObject enemy = (GameObject)Resources.Load("Prefabs/" + spawnInfo.shape);
        GameObject newEnemy = Instantiate(enemy) as GameObject;

        newEnemy.transform.position = position;

        EnemyController controller = newEnemy.GetComponent<EnemyController>();
        controller.unspawner = this.unspawner;

        Vector2 velocity = controller.getSpawnVelocity();
        velocity *= spawnInfo.velocityMag;
        newEnemy.GetComponent<Rigidbody2D>().velocity = velocity;

        if (spawnInfo.spawns % spawnInfo.spawnsUntilIncreaseDifficulty == 0)
        {
            controller.increaseDifficulty(spawnInfo);
        }

        return newEnemy;
    }
}

public class EnemySpawnInfo : MonoBehaviour
{
    public string shape;
    public int spawnInterval;
    public float velocityMag;
    public int spawnsUntilIncreaseDifficulty;

    public int spawns;

    public static int MIN_SPAWN_INTERVAL = 50;

    public EnemySpawnInfo(string shape, int spawnInterval, float velocityMag, int spawnsUntilIncreaseDifficulty)
    {
        this.shape = shape;
        this.spawnInterval = spawnInterval;
        this.velocityMag = velocityMag;
        this.spawnsUntilIncreaseDifficulty = spawnsUntilIncreaseDifficulty;

        this.spawns = 0;
    }
}
