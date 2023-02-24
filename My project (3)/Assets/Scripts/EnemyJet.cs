using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJet : MonoBehaviour
{   
    public int speed = -80;
    Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, speed));
    }
}
