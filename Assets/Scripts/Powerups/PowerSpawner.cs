using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    private PowerManager MainSpawner; 

    public GameObject Health;
    public GameObject Damage;
    public GameObject Speed; 


    // Start is called before the first frame update
    void Start()
    {
        MainSpawner = new PowerManager(Health,Damage,Speed);
    }

    // Update is called once per frame
    void Update()
    {
        MainSpawner.Call();
    }
}
