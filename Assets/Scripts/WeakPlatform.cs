using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatform : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController2D>())
        {
            _audioSource.UnPause();
            _audioSource.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController2D>())
        {
            _audioSource.Pause();
        }
    }
}
