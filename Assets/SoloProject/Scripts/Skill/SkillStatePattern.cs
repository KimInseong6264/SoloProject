using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillStatePattern
{
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
    public void StartSkillMotion()
    {
        _currentMotion.Enter();
        _currentMotion.Update();
    }
}
