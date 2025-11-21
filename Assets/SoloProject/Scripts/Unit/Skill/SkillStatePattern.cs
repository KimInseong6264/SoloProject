using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillStatePattern
{
    // 스킬모션 실행을 위한 상태 패턴 필드
    public Dictionary<Motion, ISkillMotion> MotionList { get; protected set; }
    private ISkillMotion _currentMotion;

    
    public void SetMotion(Motion newMotion)
    {
        _currentMotion?.Exit();
        _currentMotion = MotionList[newMotion];
        _currentMotion.Enter();
    }

    // DamageSystem에서 코루틴 수행으로 업데이트 수행
    public void UpdateMotion()
    {
        _currentMotion.Update();
    }
}
