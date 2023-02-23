using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingEnemy : MonoBehaviour
{
    public int pelletCount = 15;
    public GameObject pelletPrefab;
    public int pelletSpeed = 100;

    public float fireRate = 1;
    public float rotateSpeed = 0.2f;

    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.down * 2;
        StartCoroutine(PulseFire());
    }

    IEnumerator PulseFire() {
        while(true) {
            // Don't start shooting until the enemy stops moving
            if(_rigidbody.velocity.y == 0) {
                // Space each enemy bullet evenly
                int degreePerPellet = 360 / pelletCount;
                // Create each bullet
                for(int i = 0; i < pelletCount; i ++) {
                    GameObject newPellet = Instantiate(pelletPrefab, transform.position, Quaternion.Euler(0, 0, degreePerPellet*i));
                    newPellet.GetComponent<Rigidbody2D>().AddForce(newPellet.transform.up * pelletSpeed);
                }
            }
            yield return new WaitForSeconds(1 / fireRate);
        }
    }

    void Update() {
        // Move the enemy onto the screen
        if(transform.position.y <= 4) {
            _rigidbody.velocity = Vector2.zero;
        }
        // Spin the enemy
        transform.Rotate(new Vector3(0,0,rotateSpeed));
    }
}
