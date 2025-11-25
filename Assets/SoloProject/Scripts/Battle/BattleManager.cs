using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 합 이후 데미지 관련 클래스
public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public ClashSystem Clash { get; private set; }
    public DamageSystem Damage { get; private set; }

    // 배틀 중 사용할 코인 관리
    public CoinSystem PlayerCoin { get; private set; } = new();
    public CoinSystem EnemyCoin { get; private set; } = new();

    // 배틀할 유닛과 스킬 리스트
    public Dictionary<UnitType, Unit> BattleUnit { get; private set; }
    public Dictionary<UnitType, Skill> BattleSkill { get; private set; }

    private void Awake()
    {
        Instance = GetComponent<BattleManager>();

        Clash = GetComponent<ClashSystem>();
        Damage = GetComponent<DamageSystem>();
        BattleUnit = new() { { UnitType.Player, null }, { UnitType.Enemy, null } };
        BattleSkill = new() { { UnitType.Player, null }, { UnitType.Enemy, null } };
    }

    // 배틀할 대상 리스트에 추가
    public void SetBattle(UnitType unitType, Unit unit)
    {
        BattleUnit[unitType] = unit;
    }
    // 배틀할 대상의 선택 스킬 리스트에 추가
    public void SetBattle(UnitType unitType, Skill skill)
    {
        BattleSkill[unitType] = skill;
    }
    

    // 배틀 리스트 초기화
    public void InitBattleList()
    {
        PlayerCoin.GetCoinReset();
        EnemyCoin.GetCoinReset();
        foreach (var unit in BattleUnit.Keys.ToList())
            BattleUnit[unit] = null;
        foreach(var skill in  BattleSkill.Keys.ToList())
            BattleSkill[skill] = null;
    }

    // 스킬모션에 StartCoroutine을 임시로 부여
    public void GetMotionPlay(IEnumerator skillMotion)
    {
        StartCoroutine(skillMotion);
    }
}
