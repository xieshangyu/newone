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

    public int gun = 1;
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

            if(gun==1)
            {
                audio_source.PlayOneShot(Shoot_sound);
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(2,bulletSpeed));
            }

            else if (gun == 2)
            {
                
                audio_source.PlayOneShot(Shoot_sound);
                // Spawn two bullets, one on each side of the player
                GameObject newBullet1 = Instantiate(bulletPrefab, transform.position + new Vector3(-0.2f, 0, 0), Quaternion.identity);
                newBullet1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, bulletSpeed));
                  // Add force to the bullets to make them move
                GameObject newBullet2 = Instantiate(bulletPrefab, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
                newBullet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, bulletSpeed));
            }

            else if (gun == 3) {
                audio_source.PlayOneShot(Shoot_sound);

                // Spawn three bullets, one on each side and one in the middle of the player
                GameObject newBullet1 = Instantiate(bulletPrefab, transform.position + new Vector3(-0.4f, 0f, 0f), Quaternion.identity);
                GameObject newBullet2 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                GameObject newBullet3 = Instantiate(bulletPrefab, transform.position + new Vector3(0.4f, 0f, 0f), Quaternion.identity);

                // Add force to the bullets to make them move
                newBullet1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, bulletSpeed));
                newBullet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, bulletSpeed));
                newBullet3.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, bulletSpeed));
            }

        }
    }
    

    public void Add_Bullet(int bullet) {
        gun += bullet;
        Debug.Log("Bullet: " + gun);

        // livesUI.text = "LIVES: " + lives;
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
