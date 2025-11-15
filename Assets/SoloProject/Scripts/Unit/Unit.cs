using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Unit")]
public class Unit : ScriptableObject, IBatte
{

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public UnitStat Stat { get; private set; }
    [field: SerializeField] public List<Skill> SkillList;

    public List<CoinType> ClashList { get; private set; } = new List<CoinType>();

    public void ClashListReset()
    {
        ClashList.Clear();
    }

    [System.Serializable]
    public struct UnitStat
    {
        public int HP;
        public int Att;
        public int Def;
    }
}