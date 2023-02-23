using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_level4 : MonoBehaviour
{
    // Start is called before the first frame update\
    int speed = 10;
    int bulletSpeed =400;
    public int life;

    public AudioClip Shoot_sound;
    public Transform spawnPoint;
    public GameObject bulletPrefab;

    Rigidbody2D rigid_body_2D;
    AudioSource audio_source;
    GameManager game_manager;



    // public float leftBound = -0.7f;
    // public float rightBound = 0.7f;
    // public float topBound = 5f;
    // public float bottomBound = -5f;

    public GameObject explosion;
    void Start()
    {
        rigid_body_2D= GetComponent<Rigidbody2D>();
        audio_source = GetComponent<AudioSource>();
        life = 3;
        game_manager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_speed = Input.GetAxis("Horizontal")*speed;
        float y_speed = Input.GetAxis("Vertical")*speed;

        Vector3 currentPosition = transform.position;
        currentPosition.x += x_speed * Time.deltaTime;
        currentPosition.y += y_speed * Time.deltaTime;

        currentPosition.x = Mathf.Clamp(currentPosition.x, -9.3f, 9.3f);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -4.5f, 4.5f);

        transform.position = currentPosition;
        rigid_body_2D.velocity = new Vector2(x_speed,y_speed);

        if(Input.GetButtonDown("Jump"))
        { 
            if (Shoot_sound == null) {
                Debug.LogError("Shoot_sound has not been assigned.");
            }
            audio_source.PlayOneShot(Shoot_sound);
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(2,bulletSpeed));
        }
    }
    
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "enemy")
    //     {
    //         print("player-hit"+life);
    //         game_manager.KillLife();
    //         life-=1;
    //         if(life<1)
    //         {
    //             Die();
    //         }
    //     }

    // }
    // public void Die() {
    //     Instantiate(explosion,transform.position,Quaternion.identity);
    //     Destroy(gameObject);
    // }
}
