using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianguloController : MonoBehaviour
{
    const string NOME = "Triangulo";
    Collider2D unspawner;

    public static GameObject Create(Vector2 position, Vector2 velocity, Collider2D unspawner)
    {
        GameObject enemy = (GameObject)Resources.Load("Prefabs/" + NOME);
        GameObject newEnemy = Instantiate(enemy) as GameObject;

        newEnemy.transform.position = position;
        newEnemy.GetComponent<Rigidbody2D>().velocity = velocity;
        newEnemy.GetComponent<TrianguloController>().unspawner = unspawner;

        return newEnemy;
    }

    void Start()
    {

    }

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
}
