using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : ISpawn
{
    private SpawnManager _spawnManager;
    private List<GameObject> _spawnList;
    private Vector3 _spawnPos;

    public Spawn1(SpawnManager spawnManager)
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
        GameObject.Instantiate(_spawnList[0], _spawnPos, Quaternion.identity);
    }
}
