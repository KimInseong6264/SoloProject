using System;
using System.Collections;
using UnityEngine;

public class ClashManager : MonoBehaviour
{
    private CoinSystem _characterCoinToss;
    private CoinSystem _enemyCoinToss;

    public event Action OnDamageStep;

    private void Awake()
    {
        // 각 CoinSystem에서 코인토스 결과 리스트도 들고 있음
        _characterCoinToss = new CoinSystem();
        _enemyCoinToss = new CoinSystem();
    }


    public void Battle(Skill characterSkill, Skill enemySkill)
    {
        StartCoroutine(ClashRoutine(characterSkill, enemySkill));
    }

    private IEnumerator ClashRoutine(Skill characterSkill, Skill enemySkill)
    {
        yield return StartCoroutine(Clash(characterSkill, enemySkill));

        yield return StartCoroutine(ClashResult(characterSkill, enemySkill));

    }

    // 전투 시 합이라는 것을 진행(코인토스로 승부 겨루기)
    private IEnumerator Clash(Skill characterSkill , Skill enemySkill)
    {
        StartCoroutine
            (_characterCoinToss.GetCoinToss(characterSkill));

        StartCoroutine
            (_enemyCoinToss.GetCoinToss(enemySkill));

        yield return new WaitForSeconds(_characterCoinToss.ClashTime);
    }

    // 전투 종료 후 최종위력(BaskicSkillValue + ClashPower)에 따라 승자 결정
    private IEnumerator ClashResult(Skill characterSkill, Skill enemySkill)
    {
        int characterClash = characterSkill.BasicSkillValue + _characterCoinToss.ClashPower;
        int enemyClash = enemySkill.BasicSkillValue + _enemyCoinToss.ClashPower;

        if (characterClash > enemyClash)
        {
            OnDamageStep?.Invoke();
        }
        if (characterClash < enemyClash)
        {
            OnDamageStep?.Invoke();
        }
        else
        {
            
        }

        _characterCoinToss.GetReset();
        _enemyCoinToss.GetReset();
        
        yield return null;
    }
}
