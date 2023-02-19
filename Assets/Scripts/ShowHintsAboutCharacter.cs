using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ShowHintsAboutCharacter : MonoBehaviour
{
    public TextMeshProUGUI HintToShow;
    public GameObject Character;
    public GameObject CharacterBody;

    private float _fireballSpeed = 6f;
    private bool _isTriggeredFirstTime = true;
    private float _timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isTriggeredFirstTime)
        {
            HintToShow.gameObject.SetActive(true);
            DestroyCharacter();
        }
        _timer = 5f;
        _isTriggeredFirstTime = false;
    }

    private void Update()
    {
        if (!_isTriggeredFirstTime)
        {
            if (_timer <= 0f)
            {
                HintToShow.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
            _timer -= Time.deltaTime;
        }
    }

    private void DestroyCharacter()
    {
        Vector3 characterPosition = Character.transform.position;
        Destroy(Character);
        GameObject characterBody = Instantiate(CharacterBody, characterPosition, Quaternion.identity);

        ParticleSystem bodyParticleSystem = characterBody.GetComponent<ParticleSystem>();
        print(bodyParticleSystem);

        if (bodyParticleSystem)
        {
            bodyParticleSystem.Play();
        }

        Rigidbody2D characterBodyRb = characterBody.GetComponent<Rigidbody2D>();
        if (characterBodyRb.isKinematic)
        {
            characterBodyRb.velocity = Vector2.right * _fireballSpeed;
        }

        if (bodyParticleSystem)
        {
            if (!bodyParticleSystem.isPlaying)
            {
                Destroy(bodyParticleSystem);
            }
        }

    }
}
