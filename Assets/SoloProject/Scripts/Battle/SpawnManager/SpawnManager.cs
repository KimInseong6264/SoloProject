using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [field: SerializeField] public List<GameObject> SpawnList {  get; private set; }

    private List<ISpawn> _spawnCountList;
    private ISpawn _currentSpawnCount;

    public Transform SpawnPoint { get; private set; }

    
    private void Awake()
    {
        SpawnPoint = GetComponent<Transform>();
        _spawnCountList = new List<ISpawn>();

        _spawnCountList.Add(new Spawn1(this));
        _spawnCountList.Add(new Spawn2(this));
        _spawnCountList.Add(new Spawn3(this));
    }

    public void SetSpawnCount()
    {
        int index = SpawnList.Count - 1;

        if (_currentSpawnCount == _spawnCountList[index])
            return;

        _currentSpawnCount?.Exit();
        _currentSpawnCount = _spawnCountList[index];
        _currentSpawnCount.Enter();
    }

    public void UpdateSpawn()
    {
        SetSpawnCount();
        _currentSpawnCount.Update();
    }

    private void Start()
    {
        UpdateSpawn();
    }

}
