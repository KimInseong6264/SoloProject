using UnityEngine;

public class FaustHurt : IUnitState
{
    private FaustControler _faust;
    private Unit _battleUnit;

    public FaustHurt(FaustControler faust)
    {
        _faust = faust;
    }

    public void Enter()
    {
        _faust.View.OnHurtAni();

        _battleUnit = BattleManager.Instance.BattleUnit[UnitType.Enemy];
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
            _faust.SetState(State.Idle);
    }

    
}