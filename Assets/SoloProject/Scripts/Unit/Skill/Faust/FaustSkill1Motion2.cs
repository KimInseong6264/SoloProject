using System.Collections;
using UnityEngine;

// 스킬모션 생성시 변동사항
// 1. 참조 스킬 동기화
// 2. 모션 추가시, 참조 스킬 MotionList에 추가
public class FaustSkill1Motion2 : ISkillMotion
{
    private FaustSkill1 _skill;
    private int _coinCount;
    private int _basicSkillValue;
    private int _coinValue;
    private float _motionTime = 5;


    // 모션 추가시, MotionList에 생성해야 함
    public FaustSkill1Motion2(FaustSkill1 skill)
    {
        _skill = skill;
        _coinCount = skill.CoinCount;
        _basicSkillValue = skill.BasicSkillValue;
        _coinValue = skill.CoinValue;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void Update()
    {
        // DamageSystem에서 메서드 빌려와서 코루틴 실행
        DamageSystem system = BattleManager.Instance.Damage;
        system.GetMotionPlay(MotionPlay());
    }

    public IEnumerator MotionPlay()
    {
        WaitForSeconds wait = new WaitForSeconds(_motionTime);
        Debug.Log("파우스트 스킬모션2 진행");
        yield return wait;

        // 데미지 스텝 종료
        _skill.SetMotion(Motion.First);
        BattleManager.Instance.Damage.SetEndDamageStep();
        Debug.LogWarning("모션 모두 끝남");
    }
}