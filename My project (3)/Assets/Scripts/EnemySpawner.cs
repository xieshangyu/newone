using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyJetPrefab;
    public GameObject heartPrefab;
    public GameObject bossBullet;
    public GameObject waveOne;
    public GameObject waveTwo;
    public GameObject boss;

     IEnumerator Start(){
        for(int i = 0; i < 20; ++i) {
            Vector2 spawnPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(10, 20));
            Instantiate(enemyJetPrefab, spawnPos, Quaternion.identity);
            // if (i == 7 || i == 14) {
            //     Vector2 heartSpawnPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(10, 15));
            //     Instantiate(heartPrefab, heartSpawnPos, Quaternion.identity);
            // }
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(15f);
        Instantiate(waveOne, transform.position, Quaternion.identity);
        
        yield return new WaitForSeconds(15f);
        
        for(int i = 0; i <= 3; ++i) {
            Vector2 spawnPos = new Vector2(2.6f, 6);
            Instantiate(waveTwo, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(3f);
       }
        yield return new WaitForSeconds(2f);
        Instantiate(boss, new Vector2(0, 10), Quaternion.identity);
        InvokeRepeating("attackCenter", 0, 2f);
        yield return new WaitForSeconds(1);
        InvokeRepeating("attackOthers", 0, 2f);

        
   }

    public void attackCenter() {
        GameObject newBulletOne = Instantiate(bossBullet, new Vector2(0, 8), Quaternion.identity);
        newBulletOne.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -400));
    }

    public void attackOthers() {
        GameObject newBulletTwo = Instantiate(bossBullet, new Vector2(-1.7f, 4), Quaternion.identity);
        newBulletTwo.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -400));

        GameObject newBulletThree = Instantiate(bossBullet, new Vector2(1.7f, 4), Quaternion.identity);
        newBulletThree.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -400));

        GameObject newBulletFour = Instantiate(bossBullet, new Vector2(-2.8f, 4), Quaternion.identity);
        newBulletFour.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -400));

        GameObject newBulletFive = Instantiate(bossBullet, new Vector2(2.8f, 4), Quaternion.identity);
        newBulletFive.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -400));
    }
    

}
