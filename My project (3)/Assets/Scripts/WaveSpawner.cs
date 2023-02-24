using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] wavePresets;
    public float[] waveDelays;
    public string nextLevel;
    public GameObject bossPrefab;
    private bool bossFight = false;
    private int currentWave = 0;
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
            currentWave += 1;
        }
        yield return new WaitForSeconds(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!bossFight && currentWave >= wavePresets.Length) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length == 0) {
                bossFight = true;
                if(bossPrefab != null) {
                    Instantiate(bossPrefab, bossPrefab.transform.position, bossPrefab.transform.rotation);
                }
                else {
                    SceneManager.LoadScene(nextLevel);
                }
            }
        }
    }
}
