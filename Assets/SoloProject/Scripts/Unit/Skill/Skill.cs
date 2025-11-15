using UnityEngine;


public abstract class Skill : ScriptableObject
{
    [field: SerializeField] public string SkillName { get; private set; }
    [field: SerializeField] public int CoinCount { get; private set; }

    // 스킬의 기본 위력
    [field: SerializeField] public int BasicSkillValue { get; private set; }

    // 스킬의 코인값(합의 위력과 데미지를 결정)
    [field: SerializeField] public int CoinValue { get; private set; }


    public abstract void GetSkillAction();
}
