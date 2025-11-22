using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : ISpawn
{
    private SpawnManager _spawnManager;
    private List<GameObject> _spawnList;
    private Vector3 _spawnPos;
    private float _distance = 2;

    public Spawn2(SpawnManager spawnManager)
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
        float x = _spawnPos.x;
        float y = _spawnPos.y;
        float z = _spawnPos.z;

        GameObject.Instantiate
            (_spawnList[0], new Vector3(x - _distance, y, z), Quaternion.identity);

        GameObject.Instantiate
            (_spawnList[1], new Vector3(x + _distance, y, z), Quaternion.identity);

    }
}
