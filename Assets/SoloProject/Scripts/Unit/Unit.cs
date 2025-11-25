using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    protected UnitStat _initialStat;

    public string Name { get; protected set; }

    public UnitStat Stat { get; protected set; }

    public List<Skill> SkillList { get; protected set; }

    public Transform CurrentPos { get; protected set; }

    public Dictionary<State, IUnitState> StateList { get; protected set; }
    public IUnitState CurrentState { get; protected set; }

    public event Action<float, float> OnChangeHp;

    // 초기화 메서드
    public void Init(UnitDataSO unit)
    {
        Name = unit.InitialName;
        Stat = unit.InitialStat;
    }

    // 스킬 초기화 메서드
    public void InitSkillList(UnitDataSO unit)
    {
        for (int i = 0; i < SkillList.Count; i++)
        {
            SkillList[i].Init(unit.SkillList[i]);
        }
    }

    public void SetPos(Transform pos) => CurrentPos = pos;

    public void SetState(State state)
    {
        CurrentState?.Exit();
        CurrentState = StateList[state];
        CurrentState.Enter();
    }

    // 데미지를 입는 메서드
    public void TakeDamage(int damage)
    {
        Stat = Stat.SetChangeStat(hp: -damage);
        Debug.Log(Stat);
        Debug.Log(Stat.HP);

        OnChangeHp?.Invoke(Stat.HP, _initialStat.HP);
    }
}
