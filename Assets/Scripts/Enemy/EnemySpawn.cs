using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyObject;
    public Transform enemyLeftPos;
    public Transform enemyRightPos;
    public Transform enemyUpPos;
    public Transform enemyDownPos;
    [SerializeField]
    private float spawnLocation = 1;

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
            spawnLocation = Random.Range(1, 4);
            if (spawnLocation == 1)
            {
                Instantiate(enemyObject, enemyLeftPos.position, Quaternion.identity);
            }
            else if (spawnLocation == 2)
            {
                Instantiate(enemyObject, enemyRightPos.position, Quaternion.identity);
            }
            else if (spawnLocation == 3)
            {
                Instantiate(enemyObject, enemyUpPos.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyObject, enemyDownPos.position, Quaternion.identity);
            }
            
        }
    }
}
