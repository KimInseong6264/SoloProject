using System;
using System.Collections;
using System.Collections.Generic;

// 스킬 생성시 변동사항
// 1. 생성자 이름
// 2. MotionList갱신
// 3. 모션 추가시, MotionList에 추가
// 4. 모션 추가시, 해당 애니메이션 (스킬번호)로 교체
public class FaustSkill1 : SkillStatePattern, ISkill
{

    public string SkillName { get; private set; }
    public int CoinCount { get; private set; }
    public int BasicSkillValue { get; private set; }
    public int CoinValue { get; private set; }

    // 스킬 실행시 해당 모션의 애니메이션을 구독시켜서 재생
    public event Action<int> OnSkillMotion;

    // 생성자
    public FaustSkill1(SkillData skill)
    {
        Init(skill);
    }


    public void Init(SkillData skill)
    {
        SkillName = skill.Name;
        CoinCount = skill.CoinCount;
        BasicSkillValue = skill.BasicSkillValue;
        CoinValue = skill.CoinValue;

        if (MotionList == null)
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

    public void GetMotion()
    {
        if (OnSkillMotion == null)
        {
            UnityEngine.Debug.LogError(this.SkillName + "스킬모션 구독없음");
            return;
        }

        // 정상상태시, View의 OnSkillAni()가 구독
        OnSkillMotion?.Invoke(1);
    }
}