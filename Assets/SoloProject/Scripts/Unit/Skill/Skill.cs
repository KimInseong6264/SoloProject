using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/Skill")]
public class Skill : ScriptableObject
{
    public string SkillName { get; private set; }
    public int CoinVale { get; private set; }        //스킬의 코인값(합의 위력과 데미지를 결정)
    public int CoinCount { get; private set; }        //스킬의 코인 갯수
}
