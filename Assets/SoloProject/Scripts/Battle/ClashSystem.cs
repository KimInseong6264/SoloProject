using System;
using System.Collections;
using UnityEngine;

// 합 관련 클래스
public class ClashSystem : MonoBehaviour
{
    public CoinSystem PlayerCoin { get; private set; } = new();
    public CoinSystem EnemyCoin { get; private set; } = new();

    public IUnit[] BattleUnit { get; private set; } = new IUnit[2];
    public ISkill[] BattleSkill { get; private set; } = new ISkill[2];
    


    // BattleSystem이 구독
    public event Action<UnitType> OnDamageStep;


    public IUnit LeeSang;
    public IUnit Faust;

    private void Awake()
    {
        LeeSang = GetComponent<LeeSang>();
        Faust = GetComponent<Faust>();
    }

    private void Start()
    {
        BattleUnit[0] = LeeSang;
        BattleUnit[1] = Faust;
        BattleSkill[0] = LeeSang.SkillList[0];
        BattleSkill[1] = Faust.SkillList[0];
        Battle();
    }

    public void SetBattle(IUnit unit, ISkill skill, UnitType unitType )
    {
        BattleUnit[(int)unitType] = unit;
        BattleSkill[(int)unitType] = skill;
    }

    public void Battle()
    {
        if (BattleUnit[0] == null || BattleUnit[1] == null)
        {
            Debug.LogWarning("배틀 할 대상이 명확하지 않습니다.");
            return;
        }

        StartCoroutine(Clash());
    }


    // 전투 시 합이라는 것을 진행(코인토스로 승부 겨루기)
    private IEnumerator Clash()
    {
        int player = (int)UnitType.Player;
        int enemy = (int)UnitType.Enemy;

        StartCoroutine(PlayerCoin.GetCoinToss(BattleSkill[player]));

        StartCoroutine(EnemyCoin.GetCoinToss(BattleSkill[enemy]));

        yield return new WaitUntil(() => PlayerCoin.IsDone && EnemyCoin.IsDone);

        Debug.Log("합 진행 시간 종료후");

        ClashResult();
    }

    // 전투 종료 후 최종위력(BaskicSkillValue + ClashPower)에 따라 승자 결정
    private void ClashResult()
    {
        int player = (int)UnitType.Player;
        int enemy = (int)UnitType.Enemy;

        int playerClash = BattleSkill[player].BasicSkillValue + PlayerCoin.ClashPower;
        int enemyClash = BattleSkill[enemy].BasicSkillValue + EnemyCoin.ClashPower;

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

        PlayerCoin.GetReset();
        EnemyCoin.GetReset();
    }

    public void GetReset()
    {
        PlayerCoin.GetReset();
        EnemyCoin.GetReset();
        Array.Clear(BattleUnit, 0, BattleUnit.Length);
        Array.Clear(BattleSkill, 0, BattleUnit.Length);
    }
}
