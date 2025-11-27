using System.Collections;
using UnityEngine;

public class PurpleGnomeClash : IUnitState
{
    private PurpleGnomeController _purpleGnome;

    public PurpleGnomeClash(PurpleGnomeController purpleGnome)
    {
        _purpleGnome = purpleGnome;
    }

    public void Enter()
    {

        _purpleGnome.View.OnClashAni();

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

        if (enemyClash >= playerClash)
            _purpleGnome.SetState(State.Attack);
        else if (enemyClash == playerClash)
            _purpleGnome.SetState(State.Idle);
        else
            _purpleGnome.SetState(State.Hurt);
    }
}