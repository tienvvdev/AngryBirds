using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    public float obstacleHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.magnitude < obstacleHealth)
        {
            obstacleHealth -= collision.relativeVelocity.magnitude;
        }
        
        else
        {
            Destroy(gameObject);
        }
    }
}