using System.Collections.Generic;
using UnityEngine;

// 런타임 중 변화되는 값으로 사용
public interface IUnit
{
    public string Name { get; }
    public UnitStat Stat { get; }
    public List<ISkill> SkillList { get; }

    public Transform CurrentPos { get; }

    // 상태 패턴
    public Dictionary<State, IUnitState> StateList { get; }
    public IUnitState CurrentState { get; }

    public void Init(UnitData unit);

    public void SetPos(Transform pos);

    public void TakeDamage(int damage);
}
