using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject targetDoor;
    public GarbageSpawner garbageSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "FinalDoor")
            {
                SceneManager.LoadScene("Forest");
            }

            else
                targetDoor.SetActive(false);
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            targetDoor.SetActive(true);
        }
        else if (gameObject.tag == "Door")
        {
            garbageSpawner.stopSpawning = false;
        }
    }
}
