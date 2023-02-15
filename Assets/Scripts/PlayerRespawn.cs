using UnityEngine;
using TMPro;

public class PlayerRespawn : MonoBehaviour
{
    public Transform RespawnPoint;
    public GameObject PlayerPrefab;
    public GameObject BodyPrefab;
    public AudioClip DeathSound;
    public TextMeshProUGUI DeathAllowedText;

    private GameObject _playerInstance;
    private AudioSource _audioSource;
    private ParticleSystem _deathParticle;
    private int _deathAllowed = 5;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _deathParticle = PlayerPrefab.GetComponentInChildren<ParticleSystem>();
        DeathAllowedText.text = _deathAllowed.ToString();
    }

    private void Start()
    {
        _playerInstance = Instantiate(PlayerPrefab, RespawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && _deathAllowed > 0)
        {
            Instantiate(BodyPrefab, _playerInstance.transform.position, Quaternion.identity);
            ParticleSystem deathParticle = Instantiate(_deathParticle, _playerInstance.transform.position, Quaternion.identity);
            deathParticle.Play();
            _audioSource.PlayOneShot(DeathSound);
            Destroy(_playerInstance);

            _deathAllowed--;

            if(_deathAllowed == 0)
            {
                DeathAllowedText.color = Color.red;
                DeathAllowedText.text = _deathAllowed.ToString();
            }

            DeathAllowedText.text = _deathAllowed.ToString();
            _playerInstance = Instantiate(PlayerPrefab, RespawnPoint.position, Quaternion.identity);
        }
    }
}
