using System.Collections;
using UnityEngine;

// 스킬모션 생성시 변동사항
// 1. 참조 스킬 동기화
// 2. 모션 추가시, 참조 스킬 MotionList에 추가
// 3. GetMotion()에서 해당하는 애니메이션 교체
public class FaustSkill1Motion1 : ISkillMotion
{

    private FaustSkill1 _skill;
    private int _coinCount;
    private int _basicSkillValue;
    private int _coinValue;
    private int _defMultiplier = 5;
    private float _motionTime = 3;


    // 모션 추가시, MotionList에 생성해야 함
    public FaustSkill1Motion1(FaustSkill1 skill)
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

        BattleManager system = BattleManager.Instance;
        system.BattleUnit[UnitType.Enemy].TakeDamage(GetDamage());

        // BattleManager에서 메서드 빌려와서 코루틴 실행
        system.GetMotionPlay(MotionPlay());
    }

    public IEnumerator MotionPlay()
    {
        WaitForSeconds wait = new WaitForSeconds(_motionTime);
        yield return wait;

        _skill.SetMotion(Motion.Second);
        _skill.UpateSkill();
    }

    public int GetDamage()
    {
        int playerAtt = BattleManager.Instance.BattleUnit[UnitType.Player].Stat.Att;
        int enemyDef = _defMultiplier * BattleManager.Instance.BattleUnit[UnitType.Enemy].Stat.Def;

        int damage = _basicSkillValue + playerAtt - enemyDef;

        return damage;
    }

}