using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{   
    public GameObject beePrefab;

    public GameObject flyPrefab;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // for(int i=0; i<30;i++)
        // {
        //     Vector2 sqawnPos = new Vector2(Random.Range(-8.5f,8.5f),Random.Range(10,20));
        //     Instantiate(beePrefab, sqawnPos, Quaternion.identity);
        //     yield return new WaitForSeconds(.2f);
        // }
        while(true)
        {
            Vector2 sqawnPos = new Vector2(Random.Range(-8.5f,8.5f),Random.Range(10,20));
            Instantiate(beePrefab, sqawnPos, Quaternion.identity);

            Vector2 sqawnPos_2 = new Vector2(Random.Range(-8.5f,8.5f),Random.Range(10,20));
            Instantiate(flyPrefab, sqawnPos_2, Quaternion.identity);
            yield return new WaitForSeconds(3f);

            
        }
    }


}
