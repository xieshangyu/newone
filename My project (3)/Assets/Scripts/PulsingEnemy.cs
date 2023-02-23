using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingEnemy : MonoBehaviour
{
    public int pelletCount = 15;
    public GameObject pelletPrefab;
    public int pelletSpeed = 100;

    public float fireRate = 1;

    public bool pulseOnce = false;
    public float rotateSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PulseFire());
    }

    IEnumerator PulseFire() {
        while(true) {
            int degreePerPellet = 360 / pelletCount;
            for(int i = 0; i < pelletCount; i ++) {
                GameObject newPellet = Instantiate(pelletPrefab, transform.position, Quaternion.Euler(0, 0, degreePerPellet*i));
                newPellet.GetComponent<Rigidbody2D>().AddForce(newPellet.transform.up * pelletSpeed);
            }

            if(pulseOnce) { break; }

            yield return new WaitForSeconds(1 / fireRate);
        }
    }

    void Update() {
        transform.Rotate(new Vector3(0,0,rotateSpeed));
    }
}
