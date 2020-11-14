using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityMultiplier;
    public bool isOnGround = false;

    private bool _gameOver = false;
    public bool GameOver { get => _gameOver; }

    private Animator _animator;

    private const string SPEED_MULTIPLIER = "Speed multiplier";
    private const string JUMP_TRIGGER = "Jump_trig";
    private const string SPEED_F = "Speed_f";
    private const string DEATH_B = "Death_b";
    private const string DEATHTYPE_INT = "DeathType_int";
    public ParticleSystem explosion;
    public ParticleSystem rastro;
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource; // Necesario para poder reproducir los sonidos 
    private float speedMultiplier = 1;

    [Range(0, 1)]
    public float audioVolume = 1;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1);
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        speedMultiplier += Time.deltaTime / 20;
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplier);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            rastro.Stop();
            _animator.SetTrigger(JUMP_TRIGGER);
            _audioSource.PlayOneShot(jumpSound, audioVolume);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            rastro.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            explosion.Play();
            rastro.Stop();
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATHTYPE_INT, Random.Range(1, 3));
            _audioSource.PlayOneShot(crashSound, audioVolume);
            Invoke("RestartGame", 2.0f);
        }
    }

    void RestartGame()
    {
        speedMultiplier = 1;
        SceneManager.LoadSceneAsync("Prototype 3");
    }
}