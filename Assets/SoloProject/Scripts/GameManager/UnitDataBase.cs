using System.Collections.Generic;
using UnityEngine;

public class UnitDataBase : MonoBehaviour
{
    // SO추가 후 반드시 Enem에도 추가
    [SerializeField] private List<UnitDataSO> _playerList;
    [SerializeField] private List<UnitDataSO> _enemyList;
    
    public Dictionary<Player, UnitDataSO> PlayerData { get; private set; }
    public Dictionary<Enemy, UnitDataSO> EnemyData { get; private set; }

    private void Awake()
    {
        PlayerData = new Dictionary<Player, UnitDataSO>();
        EnemyData = new Dictionary<Enemy, UnitDataSO>();
        
        for (int i = 0; i < _playerList.Count; i++)
            PlayerData.Add((Player)i, _playerList[i]);
        for (int i = 0; i < _playerList.Count; i++)
            EnemyData.Add((Enemy)i, _enemyList[i]);
    }

    public UnitDataSO GetUnitDat(Player player) => PlayerData[player];
    public UnitDataSO GetUnitDat(Enemy enemy) => EnemyData[enemy];

}