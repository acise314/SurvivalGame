using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager
{
    private GameObject _healthPower;
    private GameObject _damagePower;
    private GameObject _speedPower;
    private int _typeOfPower;

    private int _counter = 0;

    public PowerManager(GameObject Health, GameObject Damage, GameObject Speed)
    {
        _healthPower = Health;
        _damagePower = Damage;
        _speedPower = Speed;
    }

    public void Call()
    {
        _typeOfPower = Random.Range(1,4);

        if (_counter > 100)
        {
            if (_typeOfPower == 1)
            {
                SpawnDamage();
            }

            if (_typeOfPower == 2)
            {
                SpawnHealth();
            }

            if (_typeOfPower == 3)
            {
                SpawnSpeed();
            }
        }

        _counter++;
    }

    public void SpawnHealth()
    {
        Object.Instantiate(_healthPower, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0f), Quaternion.identity);
        _counter = 0;
    }

    public void SpawnDamage()
    {
        Object.Instantiate(_speedPower, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0f), Quaternion.identity);
        _counter = 0;
    }

    public void SpawnSpeed()
    {
        Object.Instantiate(_damagePower, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0f), Quaternion.identity);
        _counter = 0;
    }
}
