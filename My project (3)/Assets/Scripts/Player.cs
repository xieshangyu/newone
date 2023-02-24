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

    Rigidbody2D _rigidbody2D;

    AudioSource _audioSource;
    GameManager _gameManager;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);


        if(Input.GetButtonDown("Jump")) {
            // _audioSource.PlayOneShot(shootSnd);
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletSpeed));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("bossBullet")) {
            // _gameManager.AddScore(pointValue);
            // Instantiate(explosion, transform.position, Quaternion.identity);
            // Destroy(other.gameObject);
            _gameManager.deleteLife(1);
            Destroy(other.gameObject);
        }
    }

}