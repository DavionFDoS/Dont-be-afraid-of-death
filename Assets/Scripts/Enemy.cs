using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem _deathParticles;
    private void Awake()
    {
        _deathParticles= GetComponent<ParticleSystem>();
    }
    public void OnHit()
    {
        ParticleSystem deathParticles = Instantiate(_deathParticles, transform.position, Quaternion.identity);
        deathParticles.Play();
        Destroy(gameObject);
    }
}
