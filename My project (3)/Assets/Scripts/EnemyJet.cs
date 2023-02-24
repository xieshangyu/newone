using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJet : MonoBehaviour
{   
    public int speed = -80;
    int health = 30;
    Rigidbody2D _rigidbody2D;
    public GameObject hit;
    public GameObject death;
    GameManager _gameManager;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, speed));
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            health -= 10;
            Destroy(other.gameObject);
            if (health <= 0) {     
                Instantiate(death, transform.position, Quaternion.identity);
                _gameManager.AddScore(1);
                Destroy(gameObject);
            } else {
                Instantiate(hit, transform.position, Quaternion.identity);
            }
        }

        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            _gameManager.deleteLife(1);
        }
    }
}
