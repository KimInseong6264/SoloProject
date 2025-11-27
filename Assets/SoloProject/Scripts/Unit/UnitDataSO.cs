using System;
using System.Collections.Generic;
using UnityEngine;

// 유닛들의 초기값을 설정해 줄 수 있음
// 런타임 중에도 초기화를 위한 값으로만 보존
[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Unit")]
public class UnitDataSO : ScriptableObject
{

    [field: SerializeField] public string InitialName { get; private set; }
    [field: SerializeField] public UnitStat InitialStat { get; private set; }

    [field: SerializeField] public List<SkillDataSO> SkillList { get; private set; }

    [field: SerializeField] public GameObject Prefab {  get; private set; }
}


[Serializable]
public struct UnitStat
{
    
    [SerializeField] private int _hp;
    [SerializeField] private int _att;
    [SerializeField] private int _def;

    public int HP => _hp > 0? _hp: _hp = 0;
    public int Att => _att;
    public int Def => _def;

    public UnitStat SetChangeStat(int hp = 0, int att = 0, int def = 0)
    {
        _hp += hp;
        _att += att;
        _def += def;
        return this;
    }
}
