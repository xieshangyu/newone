using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MediumBoss : MonoBehaviour
{
    public int hp = 10;
    public GameObject bulletSpawnerPrefab;
    public GameObject pulseFormation;
    public GameObject bulletImpactPrefab;
    public GameObject explosionPrefab;
    Rigidbody2D _rigidbody;
    Transform player;
    public int speed = 5;
    public float fireRate = 10f;
    enum State {MoveToScreen, MoveLeft, MoveRight}
    State currentState = State.MoveToScreen;
    GameObject[] bulletSpawners;
    TextMeshProUGUI hpUI;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hpUI = GameObject.FindGameObjectWithTag("BossHpUI").GetComponent<TextMeshProUGUI>();
        hpUI.text = "BOSS HP: " + hp;
        hpUI.color = new Color32(157, 78, 221, 255);

        Instantiate(bulletSpawnerPrefab, bulletSpawnerPrefab.transform.position, bulletSpawnerPrefab.transform.rotation);
        bulletSpawners = GameObject.FindGameObjectsWithTag("BossBulletSpawner");
        Instantiate(pulseFormation, pulseFormation.transform.position, pulseFormation.transform.rotation);
        StartCoroutine(FireBullets());
    }

    void MoveOntoScreen() {
        // If the boss isn't on the screen, move it down
        if(transform.position.y > 4.5) {
            _rigidbody.velocity = Vector2.down; 
        }
        else { // Otherwise, slide the boss left
            _rigidbody.velocity = Vector2.zero;
            currentState = State.MoveLeft;
        }
    }

    void MoveLeft() {
        // If the boss hasn't reached the left boundary, move it left
        if(transform.position.x > -3.5) {
            _rigidbody.velocity = Vector2.left * speed; 
        } else { // Otherwise, slide the boss right
            _rigidbody.velocity = Vector2.zero;
            currentState = State.MoveRight;
        }
    }

    void MoveRight() {
        // If the boss hasn't reached the right boundary, move it right
        if(transform.position.x < 3.5) {
            _rigidbody.velocity = Vector2.right * speed; 
        } else { // Otherwise, slide the boss left
            _rigidbody.velocity = Vector2.zero;
            currentState = State.MoveLeft;
        }
    }

    // Update is called once per frame
    void Update()
    {  
        // Make the boss look at the player
        hpUI.text = "BOSS HP: " + hp;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - player.position);
        switch(currentState) {
            case State.MoveToScreen:
                MoveOntoScreen();
                break;
            case State.MoveLeft:
                MoveLeft();
                break;
            case State.MoveRight:
                MoveRight();
                break;
            default:
                break;
        }
    }

    IEnumerator FireBullets() {
        while(true) {
            int spawnerIndex = (int)(Random.Range(0, bulletSpawners.Length));
            GameObject spawner = bulletSpawners[spawnerIndex];
            StartCoroutine(spawner.GetComponent<BossBulletSpawner>().FireBullet());
            print(1.0f / fireRate);
            yield return new WaitForSeconds(1.0f / fireRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")) {
            Instantiate(bulletImpactPrefab, other.transform.position, Quaternion.identity);            
            Destroy(other.gameObject);
            hp -= 1;
            if(hp <= 0) {
                hpUI.text = "BOSS HP: 0";
                
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                foreach(GameObject spawner in bulletSpawners) {
                    spawner.GetComponent<BossBulletSpawner>().DestroySelf();
                }


                foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
                    Destroy(enemy);
                }

                Destroy(gameObject);
            }
        }
    }
}
