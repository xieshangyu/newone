using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int speed = 10;
    int bulletSpeed = 400;
    public Transform spawnPoint;
    public GameObject bullet;
    Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);
    
        if (Input.GetButtonDown("Jump")) {
            GameObject newBullet = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
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
