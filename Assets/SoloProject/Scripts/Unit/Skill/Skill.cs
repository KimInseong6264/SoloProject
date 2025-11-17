using UnityEngine;

// 런타임 중에도 초기화를 위한 값으로만 보존
[CreateAssetMenu(fileName = "LeeSangSKill1", menuName = "Skill/LeeSangSKill1")]
public abstract class Skill : ScriptableObject
{
    [field: SerializeField] public string IntialSkillName { get; private set; }
    [field: SerializeField] public int IntialCoinCount { get; private set; }

    // 스킬의 기본 위력
    [field: SerializeField] public int IntialBasicSkillValue { get; private set; }

    // 스킬의 코인값(합의 위력과 데미지를 결정)
    [field: SerializeField] public int IntialCoinValue { get; private set; }
}
