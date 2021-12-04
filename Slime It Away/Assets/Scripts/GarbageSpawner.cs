using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
   public GameObject garbage;
    public float garbageSpawned = 0;
    private float time = 0;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    private void Update()
    {
        time += Time.deltaTime;
        spawnTime += Time.deltaTime;

        
        if(spawnTime>=spawnDelay)
        {
            SpawnGarbage();
            spawnTime = 0;
            spawnDelay = spawnDelay - (time / 100);
            garbageSpawned++;

            if (spawnDelay <= 0)
            {
                spawnDelay = 0.1f;
            }
        }
    }

    public void SpawnGarbage()
    {
        Instantiate(garbage, new Vector3(Random.Range(-30, 30), Random.Range(-30f, 30f), 1), new Quaternion());

    }
}
