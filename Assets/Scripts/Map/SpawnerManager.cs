using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager 
{
    private GameObject _spawner;
    private GameObject _prefab;

    private float _CheckpointN = 15f;
    private float _CheckpointS = -15f;
    private float _CheckpointE = 15f;
    private float _CheckpointW = -15f;

    private float _positiveX1 = 7.5f;
    private float _positiveX2 = 30f;


    private float _positiveY1 = 7.5f;
    private float _positiveY2 = 30f;


    private float _negativeX1 = -7.5f;
    private float _negativeX2 = -30f;


    private float _negativeY1 = -7.5f;
    private float _negativeY2 = -30f;

    private int _eastToken = 5;
    private int _northToken = 5;
    private int _southToken = 5;
    private int _westToken = 5;

    private int _increaseTokenE = 2;
    private int _increaseTokenW = 2;
    private int _increaseTokenN = 2;
    private int _increaseTokenS = 2;




    public SpawnerManager(GameObject Spawner, GameObject Prefab)
    {
        this._spawner = Spawner;
        this._prefab = Prefab;

    }

    public void Call()
    {
        CheckPoint();

        if (_eastToken > 0)
        {
            SpawnPrefabEast();
        }

        if (_westToken > 0)
        {
            SpawnPrefabWest();
        }

        if (_northToken > 0)
        {
            SpawnPrefabNorth();
        }

        if (_southToken > 0)
        {
            SpawnPrefabSouth();
        }
        

    }

    public void SpawnPrefabEast()
    {
        //East spawn
        Object.Instantiate(_prefab, new Vector3(Random.Range(_positiveX1, _positiveX2), Random.Range(_negativeY2, _positiveY2), 0f), Quaternion.identity);
        _eastToken -= 1;
    }

    public void SpawnPrefabWest()
    {
        Object.Instantiate(_prefab, new Vector3(Random.Range(_negativeX1, _negativeX2), Random.Range(_negativeY2, _positiveY2), 0f), Quaternion.identity);
        _westToken -= 1;
    }

    public void SpawnPrefabNorth()
    {
        Object.Instantiate(_prefab, new Vector3(Random.Range(_negativeX2, _positiveX2), Random.Range(_positiveY1, _positiveY2), 0f), Quaternion.identity);
        _northToken -= 1;
    }

    public void SpawnPrefabSouth()
    {
        Object.Instantiate(_prefab, new Vector3(Random.Range(_negativeX2, _positiveX2), Random.Range(_negativeY1, _negativeY2), 0f), Quaternion.identity);
        _southToken -= 1;
    }
    public void CheckPoint()
    {

        GameObject playerObject = GameObject.FindWithTag("Player");
        Transform playerTransform = playerObject.transform;
        float playerXPosition = playerTransform.position.x;
        float playerYPosition = playerTransform.position.y;


        //East
        if (playerXPosition >= _CheckpointE)
        {
            _CheckpointE += 22.5f;
            _positiveX1 += 22.5f;
            _positiveX2 += 22.5f;
            _increaseTokenE += 2;
            _eastToken += 5 + _increaseTokenE;
        }

        if (playerXPosition <= _CheckpointW)
        {
            _CheckpointW -= 22.5f;
            _negativeX1 -= 22.5f;
            _negativeX2 -= 22.5f;
            _increaseTokenW += 2;
            _westToken += 5 + _increaseTokenW;
        }

        if (playerYPosition >= _CheckpointN)
        {
            _CheckpointN += 22.5f;
            _positiveY1 += 22.5f;
            _positiveY2 += 22.5f;
            _increaseTokenN += 2;
            _northToken += 5 + _increaseTokenN;
        }

        if (playerYPosition <= _CheckpointS)
        {
            _CheckpointS -= 22.5f;
            _negativeY1 -= 22.5f;
            _negativeY2 -= 22.5f;
            _increaseTokenS += 2;
            _southToken += 5 + _increaseTokenS;
        }
    }
}
