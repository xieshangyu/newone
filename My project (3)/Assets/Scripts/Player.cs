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
    public int gunLevel = 1;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);


        if(Input.GetButtonDown("Jump")) {
            _audioSource.PlayOneShot(shootSnd);
            if(gunLevel == 1) { FireOneBullet(); }
            else if(gunLevel == 2) {FireTwoBullets(); }
            else{ FireThreeBullets(); }
        }
    }

    void FireOneBullet() {
        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletSpeed));
    }


    void FireTwoBullets() {
        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.2f, -0.2f, 0), Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletSpeed));
        newBullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.2f, -0.2f, 0), Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletSpeed));
    }


    void FireThreeBullets() {
        FireOneBullet();
        FireTwoBullets();
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (!invincible && other.CompareTag("bossBullet")) {
            _gameManager.DeleteLife(1);
            Destroy(other.gameObject);
            invincible = true;
            StartCoroutine(Flash());
        }
        if(!invincible && other.CompareTag("Enemy")) {
            _gameManager.DeleteLife(1);
            Destroy(other.gameObject);
            invincible = true;
            StartCoroutine(Flash());
        } 
        if(!invincible && other.CompareTag("EnemyBullet")) {
            _gameManager.DeleteLife(1);
            Destroy(other.gameObject);
            invincible = true;
            StartCoroutine(Flash());
        }
        if(other.CompareTag("Upgrade")) {
            Destroy(other.gameObject);
            gunLevel ++;
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