using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSpawner : MonoBehaviour
{
    public GameObject[] wavePresets;
    public float[] waveDelays;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        for(int i = 0; i < wavePresets.Length; i++) {
            GameObject wave = wavePresets[i];
            float delay = waveDelays[i % waveDelays.Length];
            Instantiate(wave, wave.transform.position, wave.transform.localRotation);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
