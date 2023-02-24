using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossJet : MonoBehaviour
{
    public int speed = -30;
    int health = 200;
    public GameObject hit;
    public GameObject death;
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {
        if(transform.position.y > 4) {
            _rigidbody2D.velocity = Vector2.down; 
        }
        else { 
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            health -= 10;
            Destroy(other.gameObject);
            _gameManager.AddScore(10);
            if (health <= 0) {     
                Instantiate(death, transform.position, Quaternion.identity);
                _gameManager.AddScore(100);
                Destroy(gameObject);
                SceneManager.LoadScene("MediumLevel");
            } else {
                Instantiate(hit, transform.position, Quaternion.identity);
            }
        }

        if (other.CompareTag("Player")) {
            _gameManager.deleteLife(1);
        }
    }
}
