using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스킬 생성시 변동사항
// 1. 생성자 이름
// 2. MotionList갱신
// 3. 모션 추가시, MotionList에 추가
public class FaustSkill1 : SkillStatePattern, ISkill
{

    public string SkillName { get; private set; }
    public int CoinCount { get; private set; }
    public int BasicSkillValue { get; private set; }
    public int CoinValue { get; private set; }


    // 생성자
    public FaustSkill1(string skillName, int coinCount, int basicSkillValue, int coinValue)
    {
        Init(skillName, coinCount, basicSkillValue, coinValue);
    }


    public void Init(string skillName, int coinCount, int basicSkillValue, int coinValue)
    {
        SkillName = skillName;
        CoinCount = coinCount;
        BasicSkillValue = basicSkillValue;
        CoinValue = coinValue;

        if (MotionList == null)
            SetMotion();
    }


    // 스킬 모션 상태 초기화
    private void SetMotion()
    {
        MotionList = new Dictionary<Motion, ISkillMotion>();
        MotionList.Add(Motion.First, new FaustSkill1Motion1(this));
        MotionList.Add(Motion.Second, new FaustSkill1Motion2(this));
        SetMotion(Motion.First);
    }
}