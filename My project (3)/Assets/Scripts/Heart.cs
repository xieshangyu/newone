using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    void Start()
    {
        int speed = Random.Range(-250, -100);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, speed));
        // _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            // _gameManager.AddScore(pointValue);
            // Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update() {
        if (transform.position.y < -6) {
            Destroy(gameObject);
        }
    }
}
