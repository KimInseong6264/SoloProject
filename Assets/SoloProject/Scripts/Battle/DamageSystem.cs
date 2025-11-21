using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private void Start()
    {
        BattleManager.Instance.Clash.OnDamageStep += GetDamageStep;
    }

    // 스킬모션에 StartCoroutine을 임시로 부여
    public void GetMotionPlay(IEnumerator skillMotion)
    {
        StartCoroutine(skillMotion);
    }

    // 스킬 데미지 계산 + 모션 시작
    private void GetDamageStep(UnitType unit)
    {
        ClashSystem clash = BattleManager.Instance.Clash;
        ISkill skill = clash.BattleSkill[(int)unit];

        Debug.LogWarning("데미지스텝" + skill);

        // 이긴 스킬의 모션 실행
        skill.UpdateMotion();
    }

    public void SetEndDamageStep()
    {
        ClashSystem clash = BattleManager.Instance.Clash;

        clash.GetReset();
    }

}
