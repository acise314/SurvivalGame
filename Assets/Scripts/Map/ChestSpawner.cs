using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestManager : MonoBehaviour
{
    private GameObject _chestPrefab;
    private int _type;
    private float _positionX;
    private float _positionY;


    public ChestManager(GameObject ChestPrefab, int Type)
    {
        this._chestPrefab = ChestPrefab;
        this._type = Type;
    }

    public void SetPos(float PositionX, float PositionY)
    {
        this._positionX = PositionX;
        this._positionY = PositionY;

        this._chestPrefab.transform.position = new Vector3(_positionX, _positionY, 0);
    }
}

public class ChestSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject ChestPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ChestManager Chest1 = new ChestManager(ChestPrefab, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
