using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public GameObject PlatformToShow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D blueCharacterBodyRb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (blueCharacterBodyRb)
        {
            if (!PlatformToShow.activeSelf)
            {
                PlatformToShow.SetActive(true);
            }
            else
            {
                PlatformToShow.SetActive(false);
            }
            Destroy(gameObject);
        }
    }
}
