using System.Collections.Generic;
using UnityEngine;

// 유닛들의 초기값을 설정해 줄 수 있음
// 런타임 중에도 초기화를 위한 값으로만 보존
[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Unit")]
public class UnitData : ScriptableObject
{

    [field: SerializeField] public string InitialName { get; private set; }
    [field: SerializeField] public UnitStat InitialStat { get; private set; }

    [field: SerializeField] public List<SkillData> SkillList {  get; private set; }

    
}


[System.Serializable]
public struct UnitStat
{
    public int HP;
    public int Att;
    public int Def;
}