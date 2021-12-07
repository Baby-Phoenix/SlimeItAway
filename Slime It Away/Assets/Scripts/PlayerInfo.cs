using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public GarbageSpawner garbageSpawner;

    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;
    public float health = 30;
    public Slider healthSlider;

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(horizontal * speed, vertical * speed);
        Vector3 scale = new Vector3(2.5f, 2.5f, 1f);

        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontal = 1;
            animator.SetBool("Move", true);
            scale.x = 2.5f;
            transform.localScale = scale;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Move", false);
            horizontal = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontal = -1;
            animator.SetBool("Move", true);
            scale.x = -2.5f;
            transform.localScale = scale;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Move", false);
            horizontal = 0;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            vertical = 1;
            animator.SetBool("Move", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Move", false);
            vertical = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            vertical = -1;
            animator.SetBool("Move", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Move", false);
            vertical = 0;
        }

        if (garbageSpawner.garbageSpawned >= health)
        {
            SceneManager.LoadScene("GameOver");
        }
        healthSlider.value = garbageSpawner.garbageSpawned;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<Score>().score++;
            garbageSpawner.garbageSpawned--;
            garbageSpawner.spawnDelay += (garbageSpawner.time / 250);
        }
    }
}
