using System;
using System.Collections.Generic;

public class CoinSystem
{
    public event Action<Skill> OnCoinToss;

    public List<CoinType> CoinToss(Skill skill)
    {
        Random coinToss = new Random();
        List<CoinType> result = new List<CoinType>();

        for (int i = 0; i < skill.CoinCount; i++)
            result.Add((CoinType)coinToss.Next(0, 2));  // 코인토스의 결과를 해당 유닛의 TossList에 차곡차곡 담는다.

        return result;
    }
}
