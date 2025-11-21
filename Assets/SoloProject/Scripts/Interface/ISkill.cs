using System.Collections;

// 런타임 중 변화되는 값으로 사용
public interface ISkill
{
    public string SkillName { get; }
    public int CoinCount { get; }

    // 스킬의 기본 위력
    public int BasicSkillValue { get; }

    // 스킬의 코인 위력(합의 위력과 데미지를 결정)
    public int CoinValue { get; }


    // 스킬 초기화
    public void Init(string skillName, int coinCount, int basicSkillValue, int coinValue);


    // 스킬모션 선택
    public void SetMotion(Motion newMotion);

    // 스킬 모션 실행
    public void UpdateMotion();

}