using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatform : MonoBehaviour
{
    private ParticleSystem _weakPlatformDestroyed;
    private void Awake()
    {
        _weakPlatformDestroyed = GetComponentInChildren<ParticleSystem>();
    }
    private void OnDestroy()
    {
        ParticleSystem weakPlatformDestroyed = Instantiate(_weakPlatformDestroyed, transform.position, Quaternion.identity);

        if (weakPlatformDestroyed)
        {
            weakPlatformDestroyed.Play();
        }

        Destroy(weakPlatformDestroyed.gameObject);
    }
}
