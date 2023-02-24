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


    public AudioClip Laser_sound;
    public Transform spawnPoint;
    public GameObject bulletPrefab;

    public GameObject laserPrefab;

    public int gun = 1;
    Rigidbody2D rigid_body_2D;
    AudioSource audio_source;
    GameManager game_manager;

    SpriteRenderer _spriteRenderer;
    public float invincibleTime = 3;
    private bool invincible = false;
    bool isFiring = false; // 是否正在持续射


    public GameObject explosion;
    void Start()
    {
        rigid_body_2D= GetComponent<Rigidbody2D>();
        audio_source = GetComponent<AudioSource>();
        life = 3;
        game_manager = GameObject.FindObjectOfType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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


        if (gun >= 4)
        {
            // 改变玩家的武器模型
            // bulletPrefab = laserPrefab;
            
            // 修改子弹速度
            // bulletSpeed = 1000;
            
            // 修改声音
            Shoot_sound = Laser_sound;
        }


        if (Input.GetButtonDown("Jump")) {
            isFiring = true;
        }
        else if (Input.GetButtonUp("Jump")) {
            isFiring = false;
        }

        if (isFiring &&gun==4) {

            Fire();
        }
        void Fire()
        {
                audio_source.PlayOneShot(Shoot_sound);
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(2,bulletSpeed));
        }

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
    void OnTriggerEnter2D(Collider2D other) {
        if(!invincible && other.CompareTag("Enemy")) {
            game_manager.AddLife(-1);
            invincible = true;
            StartCoroutine(Flash());
        } 
        if(!invincible && other.CompareTag("EnemyBullet")) {
            game_manager.AddLife(-1);
            invincible = true;
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash() {
        float flashDuration = invincibleTime / 6;
        for(int i = 0; i < 3; i++) {
            _spriteRenderer.color = Color.clear;
            yield return new WaitForSeconds(flashDuration);
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(flashDuration);
        }   
        invincible = false;
        yield return new WaitForSeconds(0);
    }
}
