using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSpawner : MonoBehaviour
{
    public float flashDuration;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public int bulletSpeed;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody;
    private bool firing = false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody.velocity = Vector2.left * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 8) {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    public IEnumerator FireBullet() {
        if(_rigidbody.velocity.x == 0 && !firing) {
            firing = true;
            float flashPeriod = flashDuration / 6;
            for(int i = 0; i < 3; i++) {
                _spriteRenderer.color = Color.red;
                yield return new WaitForSeconds(flashPeriod);
                _spriteRenderer.color = Color.white;
                yield return new WaitForSeconds(flashPeriod);
            }   
            yield return new WaitForSeconds(0);
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletSpeed);
            firing = false;
        }
        yield return new WaitForSeconds(0);

    }

}
