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
        OnClashAni();
        _purpleGnome.SetState(State.Attack);
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

        if (playerClash > enemyClash)
            _purpleGnome.View.OnClashAni();
    }
}