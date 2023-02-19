using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWeakPlatforms : MonoBehaviour
{
    private const string Breakable = "Breakable";
    private AudioSource _audioSource;
    private ParticleSystem _destroyWeakPlatformInstance;
    private int _breakable;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _breakable = LayerMask.NameToLayer(Breakable);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == _breakable)
        {
            _audioSource.Play();

            _destroyWeakPlatformInstance = Instantiate(collision.gameObject.GetComponentInChildren<ParticleSystem>(), collision.gameObject.transform.position, Quaternion.identity);

            if (_destroyWeakPlatformInstance)
            {
                _destroyWeakPlatformInstance.Play();
            }

            Destroy(collision.gameObject);

            if(!_destroyWeakPlatformInstance.isPlaying)
            {
                Destroy(_destroyWeakPlatformInstance);
            }            
        }
    }
}
