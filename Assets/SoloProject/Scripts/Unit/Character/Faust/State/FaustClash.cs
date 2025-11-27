using System.Collections;
using UnityEngine;

public class FaustClash : IUnitState
{
    private FaustControler _faust;

    public FaustClash(FaustControler faust)
    {
        _faust = faust;
    }

    public void Enter()
    {
        _faust.View.OnClashAni();

        OnClashAni();
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }

    private void OnClashAni()
    {
        int playerClash = BattleManager.Instance.PlayerCoin.ClashPower;
        int enemyClash = BattleManager.Instance.EnemyCoin.ClashPower;

        if(playerClash > enemyClash)
            _faust.SetState(State.Attack);
        else if(playerClash == enemyClash)
            _faust.SetState(State.Idle);
        else
            _faust.SetState(State.Hurt);
    }
}