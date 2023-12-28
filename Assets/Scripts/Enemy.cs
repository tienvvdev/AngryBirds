using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int healthPoints;


    public static int enemiesAlive;
    public static int maxEnemies;

    public bool enemyDied = false;

    void Start()
    {
   
        enemiesAlive++;
        maxEnemies++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.relativeVelocity.magnitude > healthPoints && enemyDied == false)
        {
            Destroy(gameObject);
            enemiesAlive--;
            enemyDied = true;
        }
    }
}