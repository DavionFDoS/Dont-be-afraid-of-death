using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharactersHandler : MonoBehaviour
{
    public GameObject[] Characters;
    public GameObject[] CharactersBodies;
    public TextMeshProUGUI DeathAllowedText;
    public AudioClip DeathSound;
    public Transform RespawnPoint;

    private AudioSource _audioSource;
    private GameObject _currentCharacter;
    private int _currentCharacterIndex = 0;
    [SerializeField]
    private int _deathAllowed = 5;
    private ParticleSystem _deathParticle;
    private float _fireballSpeed = 5;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _currentCharacter = Instantiate(Characters[0], RespawnPoint.transform.position, Quaternion.identity);
        DeathAllowedText.text = _deathAllowed.ToString();
        _deathParticle = FindObjectOfType<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && _deathAllowed > 0)
        {
            GameObject body = Instantiate(CharactersBodies[_currentCharacterIndex], _currentCharacter.transform.position, Quaternion.identity);
            Rigidbody2D bodyRb = body.GetComponent<Rigidbody2D>();
            ParticleSystem bodyParticalSystem = body.GetComponent<ParticleSystem>();

            if (bodyParticalSystem)
            {
                bodyParticalSystem.Play();
            }

            if (bodyRb.isKinematic)
            {
                bodyRb.velocity = Vector2.right * _fireballSpeed;
            }

            ParticleSystem deathParticle = Instantiate(_deathParticle, _currentCharacter.transform.position, Quaternion.identity);
            deathParticle.Play();
            _audioSource.PlayOneShot(DeathSound);

            Destroy(_currentCharacter);

            DescreaseAllowedDeath();

            DeathAllowedText.text = _deathAllowed.ToString();

            _currentCharacter = Instantiate(Characters[_currentCharacterIndex], RespawnPoint.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchTo(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchTo(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchTo(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchTo(3);
        }
    }

    private void DescreaseAllowedDeath()
    {
        _deathAllowed--;

        if (_deathAllowed == 0)
        {
            DeathAllowedText.color = Color.red;
            DeathAllowedText.text = _deathAllowed.ToString();
        }
    }

    private void SwitchTo(int characterIndex)
    {
        if (characterIndex == _currentCharacterIndex)
        {
            return;
        }

        if(characterIndex > Characters.Length - 1)
        {
            return;
        }

        Destroy(_currentCharacter);
        _currentCharacterIndex = characterIndex;
        _currentCharacter = Instantiate(Characters[_currentCharacterIndex], _currentCharacter.transform.position, _currentCharacter.transform.rotation);
    }
}
