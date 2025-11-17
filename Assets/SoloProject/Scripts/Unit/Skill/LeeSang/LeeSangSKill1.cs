using UnityEngine;

public class LeeSangSKill1 : Skill, ISkill
{
    public string SkillName { get; private set; }

    public int CoinCount { get; private set; }

    public int BasicSkillValue { get; private set; }

    public int CoinValue { get; private set; }

    public void Init()
    {
        SkillName = IntialSkillName;
        CoinCount = IntialCoinCount;
        BasicSkillValue = IntialBasicSkillValue;
        CoinValue = IntialCoinValue;
    }
}
