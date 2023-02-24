using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_prop : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;

    // player_level4 _player_Level4;
    void Start()
    {
        int speed = Random.Range(-250, -100);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, speed));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            //_gameManager.AddLife(1);
            player_level4 player = other.gameObject.GetComponent<player_level4>();
            if (player != null)
            {
                player.Add_Bullet(1); //enforce player weapon
            }
            Destroy(gameObject);
        }
    }

}