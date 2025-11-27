using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : ISpawn
{
    private UnitSpawner _spawnManager;
    private List<UnitDataSO> _spawnList;
    private Vector3 _spawnPos;
    private UnitType _spawnType;

    public Spawn1(UnitSpawner spawnManager)
    {
        _spawnManager = spawnManager;
        _spawnPos = spawnManager.SpawnPoint.position;
    }

    public void Enter()
    {
        _spawnType = _spawnManager.SpawnType;
        if (_spawnType == UnitType.Player)
            _spawnList = _spawnManager.PlayerList;
        if (_spawnType == UnitType.Enemy)
            _spawnList = _spawnManager.EnemyList;
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        GameObject.Instantiate(_spawnList[0].Prefab, _spawnPos, Quaternion.identity);
    }
}
