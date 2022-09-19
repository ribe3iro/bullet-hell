using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadradoController : EnemyController
{
    public override Vector2 getSpawnVelocity()
    {
        Vector2 velocity = new Vector2(0, -3);
        velocity.x += Random.Range(-5f, 5f);
        velocity.Normalize();

        return velocity;
    }
}
