using UnityEngine;

public class PurpleGnomeHurt : IUnitState
{
    private PurpleGnomeController _purpleGnome;
    private Unit _battleUnit;

    public PurpleGnomeHurt(PurpleGnomeController purpleGnome)
    {
        _purpleGnome = purpleGnome;
    }

    public void Enter()
    {
        _purpleGnome.View.OnHurtAni();

        _battleUnit = BattleManager.Instance.BattleUnit[UnitType.Player];
    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (_battleUnit.CurrentState == _battleUnit.StateList[State.Attack])
            return;

        else if (_battleUnit.CurrentState == _battleUnit.StateList[State.Clash])
            return;
        else
            _purpleGnome.SetState(State.Idle);
    }
}