using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    const int INCREASE_SPEED_INTERVAL = 1500;
    const int INCREASE_SPAWN_RATE_INTERVAL = 1000;

    const int MIN_SPAWN_INTERVAL = 50;

    int updateCalls = 0;
    int spawnInterval = 100;
    float velocityMag = 3;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        updateCalls++;
        if (updateCalls % spawnInterval == 0)
        {
            Vector2 pos = this.transform.position;
            pos.x += Random.Range(-6f, 6f);

            Vector2 vel = new Vector2(0, -3);
            vel.x += Random.Range(-5f, 5f);
            vel.Normalize();
            vel *= velocityMag;

            TrianguloController.Create(pos, vel);
        }
        if (updateCalls % INCREASE_SPEED_INTERVAL == 0)
        {
            velocityMag += 1f;
        }
        if (spawnInterval > MIN_SPAWN_INTERVAL && 
            updateCalls % INCREASE_SPAWN_RATE_INTERVAL == 0)
        {
            spawnInterval -= 15;
        }
    }
}
