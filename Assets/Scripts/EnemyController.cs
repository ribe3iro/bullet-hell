using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public Collider2D unspawner;

    void FixedUpdate()
    {
        float xVel = GetComponent<Rigidbody2D>().velocity.x;
        GetComponent<Animator>().SetFloat("xVelocity", xVel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == unspawner)
        {
            Destroy(this.gameObject);
        }
    }

    abstract public Vector2 getSpawnVelocity();
    abstract public void increaseDifficulty(EnemySpawnInfo spawnInfo);
}
