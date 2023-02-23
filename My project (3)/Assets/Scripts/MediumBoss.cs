using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBoss : MonoBehaviour
{
    public int hp = 10;
    Rigidbody2D _rigidbody;
    Transform player;
    public int speed = 5;

    public enum State {MoveToScreen, MoveLeft, MoveRight}
    State currentState = State.MoveToScreen;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void MoveOntoScreen() {
        // If the boss isn't on the screen, move it down
        if(transform.position.y > 4.5) {
            _rigidbody.velocity = Vector2.down; 
        }
        else { // Otherwise, slide the boss left
            _rigidbody.velocity = Vector2.zero;
            currentState = State.MoveLeft;
        }
    }

    void MoveLeft() {
        // If the boss hasn't reached the left boundary, move it left
        if(transform.position.x > -3.5) {
            _rigidbody.velocity = Vector2.left * speed; 
        } else { // Otherwise, slide the boss right
            _rigidbody.velocity = Vector2.zero;
            currentState = State.MoveRight;
        }
    }

    void MoveRight() {
        // If the boss hasn't reached the right boundary, move it right
        if(transform.position.x < 3.5) {
            _rigidbody.velocity = Vector2.right * speed; 
        } else { // Otherwise, slide the boss left
            _rigidbody.velocity = Vector2.zero;
            currentState = State.MoveLeft;
        }
    }

    // Update is called once per frame
    void Update()
    {  
        // Make the boss look at the player
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - player.position);
        switch(currentState) {
            case State.MoveToScreen:
                MoveOntoScreen();
                break;
            case State.MoveLeft:
                MoveLeft();
                break;
            case State.MoveRight:
                MoveRight();
                break;
            default:
                break;
        }
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
