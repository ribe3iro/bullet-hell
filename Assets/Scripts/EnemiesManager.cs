using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] EdgeCollider2D unspawner;

    const int INCREASE_SPEED_INTERVAL = 1500;
    const int INCREASE_SPAWN_RATE_INTERVAL = 1000;

    const int MIN_SPAWN_INTERVAL = 50;

    EnemySpawnInfo[] enemiesSpawnInfo;

    int updateCalls = 0;

    void Start()
    {
        enemiesSpawnInfo = new EnemySpawnInfo[]{
            new EnemySpawnInfo("Triangulo", 100, 3),
            new EnemySpawnInfo("Quadrado", 200, 9),
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
            /*
            if (updateCalls % INCREASE_SPEED_INTERVAL == 0)
            {
                velocityMag += 1f;
            }
            if (spawnInterval > MIN_SPAWN_INTERVAL &&
                updateCalls % INCREASE_SPAWN_RATE_INTERVAL == 0)
            {
                spawnInterval -= 15;
            }
            */
        }
    }

    private GameObject Spawn(Vector2 position, EnemySpawnInfo spawnInfo)
    {
        GameObject enemy = (GameObject)Resources.Load("Prefabs/" + spawnInfo.shape);
        GameObject newEnemy = Instantiate(enemy) as GameObject;

        newEnemy.transform.position = position;
        EnemyController controller = newEnemy.GetComponent<EnemyController>();
        controller.unspawner = this.unspawner;

        Vector2 velocity = controller.getSpawnVelocity();
        velocity *= spawnInfo.velocityMag;
        newEnemy.GetComponent<Rigidbody2D>().velocity = velocity;

        return newEnemy;
    }
}

class EnemySpawnInfo : MonoBehaviour
{
    public string shape;
    public int spawnInterval;
    public float velocityMag;

    public EnemySpawnInfo(string shape, int spawnInterval, float velocityMag)
    {
        this.shape = shape;
        this.spawnInterval = spawnInterval;
        this.velocityMag = velocityMag;
    }
}
