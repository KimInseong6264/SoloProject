using System;
using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    // 데미지스텝 종료시 알림 발송
    public event Action OnEndDamageStep;
    private void Start()
    {
        BattleManager.Instance.Clash.OnDamageStep += GetDamageStep;
        OnEndDamageStep += SpawnManager.Instance.UnitSpawn;
        OnEndDamageStep += BattleManager.Instance.PlayerCoin.GetCoinReset;
        OnEndDamageStep += BattleManager.Instance.EnemyCoin.GetCoinReset;
    }

    private void OnDisable()
    {
        BattleManager.Instance.Clash.OnDamageStep -= GetDamageStep;
        OnEndDamageStep = null;
    }


    // 스킬 데미지 계산 + 모션 시작
    private void GetDamageStep(UnitType unit)
    {
        Skill skill = BattleManager.Instance.BattleSkill[unit];

        // 이긴 스킬의 모션 실행
        skill.UpateSkill();
    }

    public void SetEndDamageStep()
    {
        BattleManager.Instance.BattleUnit[UnitType.Player].SetState(State.Idle);
        BattleManager.Instance.BattleUnit[UnitType.Enemy].SetState(State.Idle);

        GetEndDamgaeStep();
    }

    public void GetEndDamgaeStep() => OnEndDamageStep?.Invoke();
}
