using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float maxHealth = 5;

    [SerializeField]
    private float currentHealth = 1;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;
    }


    void Update()
    {
        Swarm();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            currentHealth = currentHealth - 1;
        }
    }
}
