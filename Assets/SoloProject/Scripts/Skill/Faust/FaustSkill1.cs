using System;
using System.Collections;
using System.Collections.Generic;

// 스킬 생성시 변동사항
// 1. 생성자 이름
// 2. MotionList갱신
// 3. 모션 추가시, MotionList에 추가
// 4. 모션 추가시, 해당 애니메이션 (스킬번호)로 교체
public class FaustSkill1 : Skill
{
    // 생성자
    public FaustSkill1(SkillDataSO skill)
    {
        Init(skill);
        SetMotion();
    }

    // 스킬 모션 상태 초기화
    private void SetMotion()
    {
        MotionList = new Dictionary<Motion, ISkillMotion>();
        MotionList.Add(Motion.First, new FaustSkill1Motion1(this));
        MotionList.Add(Motion.Second, new FaustSkill1Motion2(this));
        _currentMotion = MotionList[Motion.First];
    }
}