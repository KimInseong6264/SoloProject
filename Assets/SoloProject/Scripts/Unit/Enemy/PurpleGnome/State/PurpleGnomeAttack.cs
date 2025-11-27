using UnityEngine;

public class PurpleGnomeAttack : IUnitState
{
    private PurpleGnomeController _purpleGnome;
    private Skill _skill;

    public PurpleGnomeAttack(PurpleGnomeController purpleGnome)
    {
        _purpleGnome = purpleGnome;
    }

    public void Enter()
    {
        OnSkill();
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }

    private void OnSkill()
    {
        _skill = BattleManager.Instance.BattleSkill[UnitType.Enemy];
        _skill.UpateSkill();
    }
}