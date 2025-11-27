using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스킬 생성시 변동사항
// 1. 생성자 이름
// 2. MotionList갱신
// 3. 모션 추가시, MotionList에 추가
public class PurpleGnomeSkill1 : Skill
{

    // 생성자
    public PurpleGnomeSkill1(SkillDataSO skill)
    {
        Init(skill);
        SetMotion();
    }

    // 스킬 모션 상태 초기화
    private void SetMotion()
    {
        MotionList = new Dictionary<Motion, ISkillMotion>();
        MotionList.Add(Motion.First, new PurpleGnomeSill1Motion1(this));
        MotionList.Add(Motion.Second, new PurpleGnomeSill1Motion2(this));
        SetMotion(Motion.First);
    }
}