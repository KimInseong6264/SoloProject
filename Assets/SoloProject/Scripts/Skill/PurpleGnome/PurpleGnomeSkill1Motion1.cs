using System.Collections;
using UnityEngine;

// 스킬모션 생성시 변동사항
// 1. 참조 스킬 동기화
// 2. 모션 추가시, 참조 스킬 MotionList에 추가
public class PurpleGnomeSill1Motion1 : ISkillMotion
{
    private PurpleGnomeSkill1 _skill;
    private int _coinCount;
    private int _basicSkillValue;
    private int _coinValue;
    private float _motionTime = 3;


    // 모션 추가시, MotionList에 생성해야 함
    public PurpleGnomeSill1Motion1(PurpleGnomeSkill1 skill)
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
        // 스킬애니메이션 트리거
        _skill.GetMotion();
        Debug.Log("보라노움 1모션 애니메이션");

        // BattleManager에서 메서드 빌려와서 코루틴 실행
        BattleManager system = BattleManager.Instance;
        system.GetMotionPlay(MotionPlay());
    }

    public IEnumerator MotionPlay()
    {
        WaitForSeconds wait = new WaitForSeconds(_motionTime);
        Debug.Log("보라노움 스킬모션1 진행");
        yield return wait;

        _skill.SetMotion(Motion.Second);
        _skill.StartSkillMotion();
    }

}