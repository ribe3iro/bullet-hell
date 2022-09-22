using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianguloController : EnemyController
{
    private float maxSpeed;
    private const float MAX_STEERING_FORCE = 50f;

    private const int LIFESPAN = 200;
    private int updateCalls = 0;

    public override void Spawn(EnemySpawnInfo spawnInfo)
    {
        maxSpeed = spawnInfo.velocityMag;
    }

    public override void IncreaseDifficulty(EnemySpawnInfo spawnInfo)
    {
        spawnInfo.spawnInterval -= 10;
        if (spawnInfo.spawnInterval < EnemySpawnInfo.MIN_SPAWN_INTERVAL)
        {
            spawnInfo.spawnInterval = EnemySpawnInfo.MIN_SPAWN_INTERVAL;
        }

        spawnInfo.velocityMag += 0.3f;
    }

    private void FixedUpdate()
    {
        updateCalls++;
        Vector2 position = this.transform.position;
        Vector2 target = player.transform.position;

        Vector2 desired = target - position;

        desired.Normalize();
        desired *= this.maxSpeed;

        Vector2 velocity = this.GetComponent<Rigidbody2D>().velocity;

        Vector2 steer = desired - velocity;

        if (steer.magnitude > MAX_STEERING_FORCE)
        {
            steer.Normalize();
            steer *= MAX_STEERING_FORCE;
        }

        this.GetComponent<Rigidbody2D>().AddForce(steer);
    }

    private void LateUpdate()
    {
        if (updateCalls > LIFESPAN)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Vector2 velocity = this.GetComponent<Rigidbody2D>().velocity;

            float angle = Mathf.Atan2(velocity.y, velocity.x);
            angle *= Mathf.Rad2Deg;
            angle -= 90;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
