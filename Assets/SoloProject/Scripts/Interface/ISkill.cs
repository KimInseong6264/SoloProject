using System.Collections.Generic;

// 런타임 중 변화되는 값으로 사용
public interface ISkill
{
    public string SkillName { get; }
    public int CoinCount { get; }

    // 스킬의 기본 위력
    public int BasicSkillValue { get; }

    // 스킬의 코인값(합의 위력과 데미지를 결정)
    public int CoinValue { get; }


    public void Init();
}