using System.Collections.Generic;

// 런타임 중 변화되는 값으로 사용
public interface IUnit
{
    public UnitStat Stat { get; }
    public List<Skill> SkillList { get; }

    public void Init();

    public void TakeDamage(int damage);
}
