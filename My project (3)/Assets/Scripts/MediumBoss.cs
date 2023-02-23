using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBoss : MonoBehaviour
{
    public int hp = 10;
    Rigidbody2D _rigidbody;
    int wobbleCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        MoveOntoScreen();
    }

    void MoveOntoScreen() {
        while(transform.position.y > 3.5) {
            _rigidbody.velocity = Vector2.down; 
        }
        _rigidbody.velocity = Vector2.zero;
        MoveLeft();
    }

    void MoveLeft() {
        while(transform.position.x > -4) {
            _rigidbody.velocity = Vector2.left; 
        }
        _rigidbody.velocity = Vector2.zero;
        MoveRight();
    }

    void MoveRight() {
        while(transform.position.x < 4) {
            _rigidbody.velocity = Vector2.right; 
        }
        _rigidbody.velocity = Vector2.zero;
        MoveLeft();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")) {
            // _gameManager.AddScore(pointValue);
            Destroy(other.gameObject);
            hp -= 1;
            if(hp <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
