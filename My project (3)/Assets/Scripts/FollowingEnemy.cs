using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    
    public int speed;
    Transform player;
    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - player.position);
        _rigidbody.velocity = -transform.up * speed;
    }
}
