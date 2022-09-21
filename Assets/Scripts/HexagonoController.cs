using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonoController : EnemyController
{
    public override void Spawn(EnemySpawnInfo spawnInfo)
    {
        Vector2 velocity = new Vector2(0, -3);
        velocity.x += Random.Range(-5f, 5f);

        velocity.Normalize();
        velocity *= spawnInfo.velocityMag;

        this.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public override void IncreaseDifficulty(EnemySpawnInfo spawnInfo)
    {
        spawnInfo.spawnInterval -= 8;
        if (spawnInfo.spawnInterval < EnemySpawnInfo.MIN_SPAWN_INTERVAL)
        {
            spawnInfo.spawnInterval = EnemySpawnInfo.MIN_SPAWN_INTERVAL;
        }

        spawnInfo.velocityMag += 0.3f;
    }

    void FixedUpdate()
    {
        float xVel = GetComponent<Rigidbody2D>().velocity.x;
        GetComponent<Animator>().SetFloat("xVelocity", xVel);
    }
}
