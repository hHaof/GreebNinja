using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour
{

    public float spawnDelay = 3f;
    public float timeSpawn = 0f;

    private int noOfSpawn = 0;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeSpawn < spawnDelay )
        {
            timeSpawn += Time.deltaTime;
        }
        else if (timeSpawn > spawnDelay && noOfSpawn < 20)
        {
            int randomIndex = Random.Range(0, enemies.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, 55), Random.Range(-55, 25), 0);
            Instantiate(enemies[randomIndex], randomSpawnPosition, Quaternion.identity);
            timeSpawn = 0f;
            noOfSpawn++;
        }
       
    }
}
