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
    private float _motionTime;
    private int _defMultiplier = 5;


    // 모션 추가시, MotionList에 생성해야 함
    public PurpleGnomeSill1Motion1(PurpleGnomeSkill1 skill)
    {
        _skill = skill;
        _coinCount = skill.CoinCount;
        _basicSkillValue = skill.BasicSkillValue;
        _coinValue = skill.CoinValue;
        _motionTime = skill.MotionTime;
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
        system.BattleUnit[UnitType.Player].TakeDamage(GetDamage());

        // BattleManager에서 메서드 빌려와서 코루틴 실행
        system.StartCoroutine(MotionPlay());
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
        int playerAtt = BattleManager.Instance.BattleUnit[UnitType.Enemy].Stat.Att;
        int enemyDef = _defMultiplier * BattleManager.Instance.BattleUnit[UnitType.Player].Stat.Def;

        int damage = _basicSkillValue + playerAtt - enemyDef;

        if (damage < 0)
            return damage = 1;

        return damage;
    }
}