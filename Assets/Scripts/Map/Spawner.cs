using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private SpawnerManager MainPrefab;

    public GameObject spawn;
    public GameObject Prefab;


    // Start is called before the first frame update
    void Start()
    {
        MainPrefab = new SpawnerManager(spawn, Prefab);

    }

    // Update is called once per frame
    void Update()
    {
        MainPrefab.Call();
    }
}
