using System.Collections.Generic;
using UnityEngine;

public class PurpleGnomeModel : Unit
{
    public PurpleGnomeModel(UnitDataSO unit, PurpleGnomeController controller)
    {
        Init(unit);
        _initialStat = unit.InitialStat;
        SkillList = new List<Skill>();
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
}
