using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn3 : ISpawn
{
    private SpawnManager _spawnManager;
    private List<GameObject> _spawnList;
    private Vector3 _spawnPos;
    private float _distance = 4;

    public Spawn3(SpawnManager spawnManager)
    {
        _spawnManager = spawnManager;
        _spawnPos = spawnManager.SpawnPoint.position;
        _spawnList = spawnManager.SpawnList;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void Update()
    {
        float distanceX = _distance * Mathf.Cos(30 * Mathf.Deg2Rad);
        float distanceZ = _distance * Mathf.Sin(30 * Mathf.Deg2Rad);
        float x = _spawnPos.x;
        float y = _spawnPos.y;
        float z = _spawnPos.z;

        GameObject.Instantiate
            (_spawnList[0], new Vector3(x - distanceX, y, z - distanceZ), Quaternion.identity);

        GameObject.Instantiate
            (_spawnList[1], new Vector3(x + ( distanceX / 2), y, z + distanceZ), Quaternion.identity);

        GameObject.Instantiate
            (_spawnList[2], new Vector3(x + distanceX, y, z - distanceZ), Quaternion.identity);

    }
}