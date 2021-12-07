using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GarbageSpawner garbageSpawner;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
            garbageSpawner.garbageSpawned--;
        }
    }
}
