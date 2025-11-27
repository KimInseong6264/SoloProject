using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn3 : ISpawn
{
    private UnitSpawner _spawnManager;
    private List<UnitDataSO> _spawnList;
    private Vector3 _spawnPos;
    private UnitType _spawnType;
    private float _distance = 4;

    public Spawn3(UnitSpawner spawnManager)
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
        float distanceX = _distance * Mathf.Cos(30 * Mathf.Deg2Rad);
        float distanceZ = _distance * Mathf.Sin(30 * Mathf.Deg2Rad);
        float x = _spawnPos.x;
        float y = _spawnPos.y;
        float z = _spawnPos.z;

        GameObject.Instantiate
            (_spawnList[0].Prefab, new Vector3(x - distanceX, y, z - distanceZ), Quaternion.identity);

        GameObject.Instantiate
            (_spawnList[1].Prefab, new Vector3(x + ( distanceX / 2), y, z + distanceZ), Quaternion.identity);

        GameObject.Instantiate
            (_spawnList[2].Prefab, new Vector3(x + distanceX, y, z - distanceZ), Quaternion.identity);

    }
}