using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHitDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyObstacle obstacle = collision.gameObject.GetComponent<DestroyObstacle>();

        if (obstacle)
        {
            obstacle.OnHit();            
        }

        if (collision.gameObject.GetComponent<CharacterController2D>())
        {
            return;
        }

        Destroy(gameObject);
    }
}
