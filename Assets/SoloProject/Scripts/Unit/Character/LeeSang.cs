//using System.Collections.Generic;
//using UnityEngine;

//public class LeeSang : MonoBehaviour, IUnit
//{
//    [field: SerializeField] private UnitData _unit;

//    public string Name {  get; private set; }

//    public UnitStat Stat { get; private set; }

//    public List<ISkill> SkillList { get; private set; }

//    private void Awake()
//    {
//        Init();
//    }

//    public void Init()
//    {
//        Name = _unit.InitialName;
//        Stat = _unit.InitialStat;
//        InitSkillList();
//    }

//    public void InitSkillList()
//    {
//        if (SkillList == null)
//        {
//            SkillList = new List<ISkill>();
//            foreach (var skill in _unit.SkillList)
//                SkillList.Add(new LeeSangSKill1(skill));
//        }
//    }

//    public void TakeDamage(int damage)
//    {
//    }
//}
