using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController2D>())
        {
            FindObjectOfType<ReloadLevel>().ReloadCurrentScene();
        }
    }
}
