using System;
using System.Collections.Generic;

public abstract class Skill
{
    public string SkillName { get; private set; }
    public int CoinCount { get; private set; }
    public int BasicSkillValue { get; private set; }
    public int CoinValue { get; private set; }
    public float MotionTime { get; private set; }

    // 스킬 실행시 해당 모션의 애니메이션을 구독시켜서 재생
    public event Action<int> OnSkillMotion;

    // 스킬모션 실행을 위한 상태 패턴 필드
    public Dictionary<Motion, ISkillMotion> MotionList { get; protected set; }
    protected ISkillMotion _currentMotion;

    
    public void SetMotion(Motion newMotion)
    {
        _currentMotion?.Exit();
        _currentMotion = MotionList[newMotion];
        _currentMotion.Enter();
    }

    // 스킬 사용
    public void UpateSkill()
    {
        _currentMotion.Update();
    }

    public void Init(SkillDataSO skill)
    {
        SkillName = skill.Name;
        CoinCount = skill.CoinCount;
        BasicSkillValue = skill.BasicSkillValue;
        CoinValue = skill.CoinValue;
        MotionTime = skill.MotionTime;
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
