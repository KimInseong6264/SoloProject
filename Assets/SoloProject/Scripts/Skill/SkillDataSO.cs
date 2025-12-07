using System.Collections.Generic;
using UnityEngine;

// 런타임 중에도 초기화를 위한 값으로만 보존
[CreateAssetMenu(fileName = "Skill", menuName = "SkillData/Skill")]
public class SkillDataSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int CoinCount { get; private set; }

    // 스킬의 기본 위력
    [field: SerializeField] public int BasicSkillValue { get; private set; }

    // 스킬의 코인값(합의 위력과 데미지를 결정)
    [field: SerializeField] public int CoinValue { get; private set; }

    [field: SerializeField] public float MotionTime { get; private set; }


}
