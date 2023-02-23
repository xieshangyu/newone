using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pointValue;
    public int hp = 10;
    GameManager _gameManager;

    public GameObject hit;
    public GameObject death;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        print(_gameManager);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")) {
            _gameManager.AddScore(pointValue);
            Destroy(other.gameObject);
            hp -= 1;
            if(hp <= 0) {
                Instantiate(death, transform.position, Quaternion.identity);
                Destroy(gameObject);
            } else {
                Instantiate(hit, transform.position, Quaternion.identity);
            }
        }
    }
}
