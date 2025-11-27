using System;
using System.Collections;
using UnityEngine;

// 합 관련 클래스
public class ClashSystem : MonoBehaviour
{
    private Unit _player;
    private Unit _enemy;
    private Skill _playerSkill;
    private Skill _enemySkill;

    // BattleSystem이 구독
    public event Action<UnitType> OnDamageStep;

    private void SetBattle()
    {
        _player = BattleManager.Instance.BattleUnit[UnitType.Player];
        _playerSkill = BattleManager.Instance.BattleSkill[UnitType.Player];

        _enemy = BattleManager.Instance.BattleUnit[UnitType.Enemy];
        _enemySkill = BattleManager.Instance.BattleSkill[UnitType.Enemy];
    }

    public void Battle()
    {
        SetBattle();
        if (_player == null || _enemy == null)
        {
            Debug.LogWarning("배틀 할 대상이 명확하지 않습니다.");
            return;
        }
        _player.SetState(State.Move);
        _enemy.SetState(State.Move);

        StartCoroutine(Clash());
    }


    // 전투 시 합이라는 것을 진행(코인토스로 승부 겨루기)
    private IEnumerator Clash()
    {
        CoinSystem player = BattleManager.Instance.PlayerCoin;
        CoinSystem enemy = BattleManager.Instance.EnemyCoin;

        StartCoroutine(player.GetCoinToss(_playerSkill));

        StartCoroutine(enemy.GetCoinToss(_enemySkill));

        yield return new WaitUntil(() => player.IsDone && enemy.IsDone);

        ClashResult();
    }

    // 전투 종료 후 최종위력(BaskicSkillValue + ClashPower)에 따라 승자 결정
    private void ClashResult()
    {
        CoinSystem player = BattleManager.Instance.PlayerCoin;
        CoinSystem enemy = BattleManager.Instance.EnemyCoin;

        int playerClash = _playerSkill.BasicSkillValue + player.ClashPower;
        int enemyClash = _enemySkill.BasicSkillValue + enemy.ClashPower;

        Debug.Log($"캐릭터: {playerClash} / 에너미: {enemyClash}");

        if (playerClash > enemyClash)
        {
            OnDamageStep?.Invoke(UnitType.Player);
            Debug.Log($"캐릭터 승");
        }
        else if (playerClash < enemyClash)
        {
            Debug.Log(OnDamageStep);
            OnDamageStep?.Invoke(UnitType.Enemy);
            Debug.Log("에너미 승");
        }
        else
        {
            BattleManager.Instance.Damage.GetEndDamgaeStep();
        }
    }

}
