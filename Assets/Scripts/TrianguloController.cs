using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianguloController : MonoBehaviour
{
    const string NOME = "Triangulo";

    public static GameObject Create(Vector2 position, Vector2 velocity)
    {
        GameObject enemy = (GameObject)Resources.Load("Prefabs/" + NOME);
        GameObject newEnemy = Instantiate(enemy) as GameObject;

        newEnemy.transform.position = position;
        newEnemy.GetComponent<Rigidbody2D>().velocity = velocity;

        return newEnemy;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        
    }
}
