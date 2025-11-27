using System.Collections.Generic;
using UnityEngine;


public class FaustModel : Unit
{
    public FaustModel(UnitDataSO unit , FaustControler controler)
    {
        Init(unit);
        _initialStat = unit.InitialStat;
        SkillList = new List<Skill>();
        foreach (var skill in unit.SkillList)
        {
            SkillList.Add(new FaustSkill1(skill));
        }

        // 상태패턴 세팅
        StateList = new Dictionary<State, IUnitState>();
        StateList.Add(State.Idle, new FaustIdle(controler));
        StateList.Add(State.Move, new FaustMove(controler));
        StateList.Add(State.Hurt, new FaustHurt(controler));
        StateList.Add(State.Clash, new FaustClash(controler));
        StateList.Add(State.Attack, new FaustAttack(controler));
        CurrentState = StateList[State.Idle];
    }
}