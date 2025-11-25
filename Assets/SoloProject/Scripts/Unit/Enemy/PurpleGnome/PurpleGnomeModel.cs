using System.Collections.Generic;
using UnityEngine;

public class PurpleGnomeModel : IUnit
{
    public string Name { get; private set; }

    public UnitStat Stat { get; private set; }

    public List<ISkill> SkillList { get; private set; }

    public Transform CurrentPos { get; private set; }

    public Dictionary<State, IUnitState> StateList { get; private set; }

    public IUnitState CurrentState { get; private set; }

    public PurpleGnomeModel(UnitData unit, PurpleGnomeController controller)
    {
        Init(unit);
        SkillList = new List<ISkill>();
        foreach (var skill in unit.SkillList)
        {
            SkillList.Add(new PurpleGnomeSkill1(skill));

            // 상태패턴 세팅
            StateList = new Dictionary<State, IUnitState>();
            StateList.Add(State.Idle, new PurpleGnomeIdle(controller));
            StateList.Add(State.Move, new PurpleGnomeMove(controller));
            StateList.Add(State.Clash, new PurpleGnomeClash(controller));
            StateList.Add(State.Attack, new PurpleGnomeAttack(controller));
            CurrentState = StateList[State.Idle];
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
