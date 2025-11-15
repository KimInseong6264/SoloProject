using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private CoinSystem CharacterCoinResult;
    private CoinSystem EnemyCoinResult;

    private void Awake()
    {
        // 각 CoinSystem에서 코인토스 결과 리스트도 들고 있음
        CharacterCoinResult = new CoinSystem();
        EnemyCoinResult = new CoinSystem();
    }

    // 전투 시 합이라는 것을 진행(코인토스로 승부 겨루기)
    public void Clash(Skill characterSkill , Skill enemySkill)
    {
        StartCoroutine(CharacterCoinResult.GetCoinToss(characterSkill));

        StartCoroutine(EnemyCoinResult.GetCoinToss(enemySkill));
    }
}
