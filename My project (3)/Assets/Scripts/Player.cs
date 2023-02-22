using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int speed = 10;
    int bulletSpeed = 600;
    public Transform bulletPoint;
    public GameObject bulletPrefab;
    Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);
    
        if (Input.GetButtonDown("Jump")) {
            GameObject newBullet = Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletSpeed));
        }
    }
}
