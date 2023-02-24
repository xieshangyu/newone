using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrade : MonoBehaviour
{
    public int speed = 10;
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.down * speed;
    }
}
