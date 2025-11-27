using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public List<UnitDataSO> PlayerList {  get; private set; }
    public List<UnitDataSO> EnemyList {  get; private set; }
    public UnitType SpawnType { get; private set; }


    private List<ISpawn> _spawnCountList;
    private ISpawn _currentSpawnCount;
    

    public Transform SpawnPoint { get; private set; }


    private void Awake()
    {
        PlayerList = GameManager.Instance.SelectedPlayer;

        SpawnPoint = GetComponent<Transform>();
        _spawnCountList = new List<ISpawn>();

        _spawnCountList.Add(new Spawn1(this));
        _spawnCountList.Add(new Spawn2(this));
        _spawnCountList.Add(new Spawn3(this));
    }

    private void Start()
    {
        EnemyList = SpawnManager.Instance.Wave.EnmemyList;
        UpdateSpawn(UnitType.Player);
    }

    public void SetSpawnCount()
    {
        int index = 0;
        PlayerList = GameManager.Instance.SelectedPlayer;
        EnemyList = SpawnManager.Instance.Wave.EnmemyList;

        if (gameObject.CompareTag("PlayerSpawner"))
        {
            index = PlayerList.Count - 1;
            SpawnType = UnitType.Player;
        }

        else if (gameObject.CompareTag("EnemySpawner"))
        {
            index = EnemyList.Count - 1;
            SpawnType = UnitType.Enemy;
        }

        else 
            return;

        _currentSpawnCount?.Exit();
        _currentSpawnCount = _spawnCountList[index];
        _currentSpawnCount.Enter();
    }

    public void UpdateSpawn(UnitType unitType)
    {

        Unit unit = BattleManager.Instance.BattleUnit[unitType];

        if (unit != null)
        {
            IEnumerator wait()
            {
                yield return new WaitForSeconds(1f);
                unit.CurrentPos.position = SpawnPoint.position;
            }

            StartCoroutine(wait());
            return;
        }

        
        SetSpawnCount();
        _currentSpawnCount.Update();
    }


}
