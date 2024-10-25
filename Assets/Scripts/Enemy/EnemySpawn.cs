using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyObject;
    public Transform enemyPos;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            timer = 0;
            print("Enemy Shoot");
            SpawnEnemy();
            Destroy(gameObject);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyObject, enemyPos.position, Quaternion.identity);
    }
}
