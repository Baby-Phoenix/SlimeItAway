using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageSpawner : MonoBehaviour
{
   public GameObject garbage;
    public float garbageSpawned = 0;
    public float time = 0;
    public bool stopSpawning;
    public float spawnTime;
    public float spawnDelay;
    [SerializeField] int minX, maxX, minY, maxY;
    

    private void Update()
    {
        if (!stopSpawning)
        {
            time += Time.deltaTime;
            spawnTime += Time.deltaTime;


            if (spawnTime >= spawnDelay)
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
    }

    public void SpawnGarbage()
    {
        Instantiate(garbage, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1), new Quaternion());

    }
}
