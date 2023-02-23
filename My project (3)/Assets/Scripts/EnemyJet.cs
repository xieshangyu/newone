using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJet : MonoBehaviour
{   
    public int speed = -50;
    int health = 30;
    Rigidbody2D _rigidbody2D;
    public GameObject hit;
    public GameObject death;
    // GameManager _gameManager;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, speed));
    }

    void Update() {
        if (transform.position.y < -6) {
            Destroy(gameObject);
        }
        // print(health);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            // _gameManager.AddScore(pointValue);
            // Destroy(other.gameObject);
            health -= 10;
            if (health <= 0) {     
                Instantiate(death, transform.position, Quaternion.identity);
                // _gameManager.AddScore(10);
                Destroy(gameObject);
            } else {
                Instantiate(hit, transform.position, Quaternion.identity);
            }
        }
    }
}
