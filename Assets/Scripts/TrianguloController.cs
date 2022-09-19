using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianguloController : EnemyController
{
    public override Vector2 getSpawnVelocity()
    {
        Vector2 velocity = new Vector2(0, -3);
        velocity.x += Random.Range(-5f, 5f);
        velocity.Normalize();

        return velocity;
    }

    public override void increaseDifficulty(EnemySpawnInfo spawnInfo)
    {
        spawnInfo.spawnInterval -= 8;
        if (spawnInfo.spawnInterval < EnemySpawnInfo.MIN_SPAWN_INTERVAL)
        {
            spawnInfo.spawnInterval = EnemySpawnInfo.MIN_SPAWN_INTERVAL;
        }

        spawnInfo.velocityMag += 0.3f;
    }
}
