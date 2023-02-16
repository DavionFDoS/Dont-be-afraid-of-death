using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHitDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.OnHit();
        }

        if (collision.gameObject.GetComponent<CharacterController2D>())
        {
            return;
        }

        Destroy(gameObject);
    }
}
