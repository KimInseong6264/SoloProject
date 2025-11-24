using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private void Start()
    {
        BattleManager.Instance.Clash.OnDamageStep += GetDamageStep;
    }

    private void OnDisable()
    {
        BattleManager.Instance.Clash.OnDamageStep -= GetDamageStep;
    }

    // 스킬 데미지 계산 + 모션 시작
    private void GetDamageStep(UnitType unit)
    {
        ClashSystem clash = BattleManager.Instance.Clash;
        ISkill skill = clash.BattleSkill[(int)unit];

        Debug.LogWarning("데미지스텝" + skill);

        // 이긴 스킬의 모션 실행
        skill.StartSkillMotion();
    }

    public void SetEndDamageStep()
    {
        ClashSystem clash = BattleManager.Instance.Clash;

        clash.GetReset();
    }

}
