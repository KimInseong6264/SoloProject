using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 다른 클래스에서는 코인 시스템을 new로 받아오기만 하면 됨
public class CoinSystem
{
    public List<CoinType> TossResult { get; private set; } = new();
    public int ClashPower { get; private set; }

    // 코인토스가 모두 끝나면 True
    public bool IsDone { get; private set; } = false;


    public CoinType GetCoinToss()
    {
        CoinType random = (CoinType)Random.Range(0, 2);
        TossResult.Add(random);

        return random;
    }

    public IEnumerator GetCoinToss(Skill skill, float waitTime = 0)
    {
        var wait = new WaitForSeconds(waitTime / skill.CoinCount);

        for (int i = 0; i < skill.CoinCount; i++)
        {
            int random = (int)GetCoinToss();
            ClashPower += random * skill.CoinValue;
            yield return wait;
        }
        IsDone = true;
    }

    public void GetCoinReset()
    {
        TossResult.Clear();
        ClashPower = 0;
        IsDone = false;
    }
}
