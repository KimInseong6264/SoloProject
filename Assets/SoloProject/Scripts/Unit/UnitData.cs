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
    public int HP { get; private set; }
    public int Att { get; private set; }
    public int Def { get; private set; }


    // 리턴한 값을 다시 Stat 프로퍼티에 대입해주어야 한다.( Stat = Stat.SetChangeStat(); )
    public UnitStat SetChangeStat(int hp = 0, int att = 0, int def = 0)
    {
        HP += hp;
        Att += att;
        Def += def;

        return this;
    }
}