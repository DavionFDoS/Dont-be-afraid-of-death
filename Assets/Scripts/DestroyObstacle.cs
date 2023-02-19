using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private AudioSource _audioSource;
    private ParticleSystem _destroyObstacleParticles;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _destroyObstacleParticles = GetComponentInChildren<ParticleSystem>();
    }

    public void OnHit()
    {
        AudioSource.PlayClipAtPoint(_audioSource.clip, transform.position);
        ParticleSystem deathParticles = Instantiate(_destroyObstacleParticles, transform.position, Quaternion.identity);
        deathParticles.Play();

        if (!deathParticles.isPlaying)
        {
            Destroy(deathParticles);
        }

        Destroy(gameObject);
    }
}