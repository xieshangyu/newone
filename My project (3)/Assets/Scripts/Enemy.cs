using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pointValue;
    public int hp = 10;
    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // _gameManager = GameObject.FindObjectOfType<GameManager>();
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
