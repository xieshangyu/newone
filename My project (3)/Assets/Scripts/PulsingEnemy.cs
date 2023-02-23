using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingEnemy : MonoBehaviour
{
    public int pelletCount = 15;
    public GameObject pelletPrefab;
    public int pelletSpeed;

    public float fireRate;

    public bool pulseOnce = false;
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
}
