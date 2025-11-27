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
        BattleManager system = BattleManager.Instance;

        int playerClash = system.BattleSkill[UnitType.Player].BasicSkillValue + system.PlayerCoin.ClashPower;
        int enemyClash = system.BattleSkill[UnitType.Enemy].BasicSkillValue + system.EnemyCoin.ClashPower;

        if (enemyClash > playerClash)
            _purpleGnome.SetState(State.Attack);
        else if (enemyClash == playerClash)
            _purpleGnome.SetState(State.Idle);
        else
            _purpleGnome.SetState(State.Hurt);
    }
}