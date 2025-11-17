using System.Collections.Generic;
using UnityEngine;

public class LeeSang : MonoBehaviour, IUnit
{
    [field: SerializeField] private UnitData _unit;

    public string Name {  get; private set; }

    public UnitStat Stat { get; private set; }

    public List<Skill> SkillList { get; private set; }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Name = _unit.InitialName;
        Stat = _unit.InitialStat;
        SkillList = _unit.InitialSkillList;
    }

    public void TakeDamage(int damage)
    {
    }
}
