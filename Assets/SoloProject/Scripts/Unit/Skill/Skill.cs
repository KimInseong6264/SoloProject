using UnityEngine;


public abstract class Skill : ScriptableObject
{
    [SerializeField] private string _skillName;
    [SerializeField] private int _coinValue;
    [SerializeField] private int _coinCount;

    public string SkillName { get => _skillName; private set => _skillName = value; }

    // 스킬의 코인값(합의 위력과 데미지를 결정)
    public int CoinValue { get => _coinValue; private set => _coinValue = value; }

    // 스킬의 코인 갯수
    public int CoinCount { get => _coinCount; private set => _coinCount = value; }

    public abstract void GetSkillAction();
}
