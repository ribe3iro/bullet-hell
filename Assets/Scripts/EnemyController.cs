using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    protected Collider2D unspawner;
    protected GameObject player;

    public static void GenerateEnemy(EnemySpawnInfo spawnInfo, Vector2 spawnPosition, Collider2D unspawner, GameObject player)
    {
        spawnInfo.spawns++;

        GameObject enemy = (GameObject)Resources.Load("Prefabs/" + spawnInfo.shape);
        GameObject newEnemy = Instantiate(enemy) as GameObject;

        newEnemy.transform.position = spawnPosition;

        EnemyController controller = newEnemy.GetComponent<EnemyController>();
        controller.unspawner = unspawner;
        controller.player = player;

        controller.Spawn(spawnInfo);

        if (spawnInfo.spawns % spawnInfo.spawnsUntilIncreaseDifficulty == 0)
        {
            controller.IncreaseDifficulty(spawnInfo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == unspawner)
        {
            Destroy(this.gameObject);
        }
    }

    abstract public void Spawn(EnemySpawnInfo spawnInfo);
    abstract public void IncreaseDifficulty(EnemySpawnInfo spawnInfo);
}
