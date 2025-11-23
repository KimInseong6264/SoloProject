using System.Collections.Generic;

// 런타임 중 변화되는 값으로 사용
public interface IUnit
{
    public UnitStat Stat { get; }
    public List<ISkill> SkillList { get; }

    public void Init(UnitData unit);

    public void TakeDamage(int damage);
}
