using System;
using System.Collections;
using UnityEngine;

// 합 관련 클래스
public class ClashSystem : MonoBehaviour
{
    private CoinSystem _playerCoin = new();
    private CoinSystem _enemyCoin = new();

    public IUnit[] BattleUnit { get; set; } = new IUnit[2];
    public ISkill[] BattleSkill { get; set; } = new ISkill[2];



    public event Action<UnitType> OnDamageStep;


    //[SerializeField] Skill skill1;
    //[SerializeField] Skill skill2;

    //private void Start()
    //{
    //    Battle(skill1, skill2);
    //}

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

        StartCoroutine(_playerCoin.GetCoinToss(BattleSkill[player]));

        StartCoroutine(_enemyCoin.GetCoinToss(BattleSkill[enemy]));

        yield return new WaitUntil(() => _playerCoin.IsDone && _enemyCoin.IsDone);

        Debug.Log("합 진행 시간 종료후");

        ClashResult();
    }

    // 전투 종료 후 최종위력(BaskicSkillValue + ClashPower)에 따라 승자 결정
    private void ClashResult()
    {
        int player = (int)UnitType.Player;
        int enemy = (int)UnitType.Enemy;

        int playerClash = BattleSkill[player].BasicSkillValue + _playerCoin.ClashPower;
        int enemyClash = BattleSkill[enemy].BasicSkillValue + _enemyCoin.ClashPower;

        Debug.Log($"캐릭터: {playerClash} / 에너미: {enemyClash}");

        if (playerClash > enemyClash)
        {
            OnDamageStep?.Invoke(UnitType.Player);
            Debug.LogWarning($"캐릭터 승");
        }
        else if (playerClash < enemyClash)
        {
            OnDamageStep?.Invoke(UnitType.Enemy);
            Debug.LogWarning("에너미 승");
        }
        else
        {
            Debug.LogWarning("재대결");
            
        }

        _playerCoin.GetReset();
        _enemyCoin.GetReset();
    }
}
