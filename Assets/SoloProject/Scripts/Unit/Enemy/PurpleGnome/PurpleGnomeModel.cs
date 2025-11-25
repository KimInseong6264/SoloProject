using System.Collections.Generic;
using UnityEngine;

public class PurpleGnomeModel : IUnit
{
    public string Name { get; private set; }

    public UnitStat Stat { get; private set; }

    public List<ISkill> SkillList { get; private set; }

    public Transform CurrentPos {  get; private set; }

    public PurpleGnomeModel(UnitData unit)
    {
        Init(unit);
        SkillList = new List<ISkill>();
        foreach (var skill in unit.SkillList)
        {
            SkillList.Add(new PurpleGnomeSkill1(skill));
        }
    }

    // 초기화 메서드
    public void Init(UnitData unit)
    {
        Name = unit.InitialName;
        Stat = unit.InitialStat;
    }

    // 스킬 초기화 메서드
    public void InitSkillList(UnitData unit)
    {
        for (int i = 0; i < SkillList.Count; i++)
        {
            SkillList[i].Init(unit.SkillList[i]);
        }
    }

    public void SetPos(Transform pos)
    {
        CurrentPos = pos;
    }

    public void TakeDamage(int damage)
    {
        Stat = Stat.SetChangeStat(hp: -damage);
        UnityEngine.Debug.Log(Stat.HP);
    }
}
