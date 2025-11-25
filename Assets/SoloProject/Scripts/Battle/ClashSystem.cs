using System;
using System.Collections;
using UnityEngine;

// 합 관련 클래스
public class ClashSystem : MonoBehaviour
{
    private IUnit _player;
    private IUnit _enemy;
    private ISkill _playerSkill;
    private ISkill _enemySkill;


    // 배틀 시작을 알려 유닛들의 상태를 변화시킬 이벤트
    // 각 유닛의 OnClick에서 구독
    public event Action<State> OnBattleStart;

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

        OnBattleStart?.Invoke(State.Move);

        StartCoroutine(Clash());
    }


    // 전투 시 합이라는 것을 진행(코인토스로 승부 겨루기)
    private IEnumerator Clash()
    {
        Debug.Log("합진행");
        CoinSystem player = BattleManager.Instance.PlayerCoin;
        CoinSystem enemy = BattleManager.Instance.EnemyCoin;

        StartCoroutine(player.GetCoinToss(_playerSkill));

        StartCoroutine(player.GetCoinToss(_enemySkill));

        yield return new WaitUntil(() => player.IsDone && enemy.IsDone);

        Debug.Log("합 진행 시간 종료후");

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
            Debug.Log(OnDamageStep);
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
            Debug.LogWarning("재대결");
            
        }

        player.GetCoinReset();
        enemy.GetCoinReset();
    }

}
