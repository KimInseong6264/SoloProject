using UnityEngine;

public class FaustAttack : IUnitState
{
    private FaustControler _faust;
    private Skill _skill;

    public FaustAttack(FaustControler faust)
    {
        _faust = faust;
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
        _skill = BattleManager.Instance.BattleSkill[UnitType.Player];
        _skill.UpateSkill();
    }
}