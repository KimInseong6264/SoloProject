using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem
{
    public List<CoinType> TossResult;
    public int ClashPower;

    public IEnumerator GetCoinToss(Skill skill)
    {
        WaitForSeconds wait = new WaitForSeconds(15 / skill.CoinCount);
        int random;

        for (int i = 0; i < skill.CoinCount; i++)
        {
            random = Random.Range(0, 2);
            TossResult.Add((CoinType)random);
            ClashPower += random * skill.CoinValue;
            yield return wait;
        }
    }

    public void GetReset()
    {
        TossResult.Clear();
        ClashPower = 0;
    }
}
