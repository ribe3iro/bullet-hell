using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadradoController : EnemyController
{
    public override void Spawn(EnemySpawnInfo spawnInfo)
    {
        Vector2 velocity = new Vector2(0, -1);
        velocity.x = Random.Range(0, 1) < 0.5f ? 1 : -1;
        velocity.x *= Random.Range(3, 5);

        velocity.Normalize();
        velocity *= spawnInfo.velocityMag;

        this.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public override void IncreaseDifficulty(EnemySpawnInfo spawnInfo)
    {
        spawnInfo.spawnInterval -= 10;
        if (spawnInfo.spawnInterval < EnemySpawnInfo.MIN_SPAWN_INTERVAL)
        {
            spawnInfo.spawnInterval = EnemySpawnInfo.MIN_SPAWN_INTERVAL;
        }

        spawnInfo.velocityMag += 0.4f;
    }

    void FixedUpdate()
    {
        float xVel = GetComponent<Rigidbody2D>().velocity.x;
        GetComponent<Animator>().SetFloat("xVelocity", xVel);
    }
}
