using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int speed = 10;
    int bulletSpeed = 600;
    public AudioClip shootSnd;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float invincibleTime = 3;
    private bool invincible = false;
    Rigidbody2D _rigidbody2D;

    AudioSource _audioSource;
    GameManager _gameManager;
    SpriteRenderer _spriteRenderer;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);


        if(Input.GetButtonDown("Jump")) {
            print("test");
            // _audioSource.PlayOneShot(shootSnd);
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletSpeed));
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(!invincible && other.CompareTag("Enemy")) {
            _gameManager.AddLife(-1);
            invincible = true;
            StartCoroutine(Flash());
        } 
        if(!invincible && other.CompareTag("EnemyBullet")) {
            _gameManager.AddLife(-1);
            invincible = true;
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash() {
        float flashDuration = invincibleTime / 6;
        for(int i = 0; i < 3; i++) {
            _spriteRenderer.color = Color.clear;
            yield return new WaitForSeconds(flashDuration);
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(flashDuration);
        }   
        invincible = false;
        yield return new WaitForSeconds(0);
    }
}