using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnItems;
    Transform randomSpawnPoint;
    public float minSpawnTime;
    public float maxSpawnTime;
    float timeBetweenSpawns;
    float nextSpawnTime;

    private void Start()
    {
        timeBetweenSpawns = maxSpawnTime;
    }

    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomSpawnItem = spawnItems[Random.Range(0, spawnItems.Length)];
            Instantiate(randomSpawnItem, randomSpawnPoint.position, randomSpawnPoint.rotation);
            timeBetweenSpawns -= minSpawnTime / maxSpawnTime;
            if(timeBetweenSpawns < minSpawnTime)
            {
                timeBetweenSpawns = minSpawnTime;
            }

            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }

}
