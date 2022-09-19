using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadradoController : EnemyController
{
    public override Vector2 getSpawnVelocity()
    {
        Vector2 velocity = new Vector2(0, -1);
        velocity.x = Random.Range(0, 1) < 0.5f ? 1 : -1;
        velocity.x *= Random.Range(3, 5);

        velocity.Normalize();

        return velocity;
    }

    public override void increaseDifficulty(EnemySpawnInfo spawnInfo)
    {
        spawnInfo.spawnInterval -= 15;
        if (spawnInfo.spawnInterval < EnemySpawnInfo.MIN_SPAWN_INTERVAL)
        {
            spawnInfo.spawnInterval = EnemySpawnInfo.MIN_SPAWN_INTERVAL;
        }

        spawnInfo.velocityMag += 0.4f;
    }
}
