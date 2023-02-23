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


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);


        if(Input.GetButtonDown("Jump")) {
            print("test");
            _audioSource.PlayOneShot(shootSnd);
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletSpeed));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("EnemyJet")) {
            // _gameManager.AddScore(pointValue);
            // Instantiate(explosion, transform.position, Quaternion.identity);
            // Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}