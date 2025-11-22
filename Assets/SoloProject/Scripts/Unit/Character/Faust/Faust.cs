using System.Collections.Generic;
using UnityEngine;

public class Faust : MonoBehaviour, IUnit
{
    [SerializeField] private UnitData _unit;

    public string Name { get; private set; }

    public UnitStat Stat { get; private set; }

    public List<ISkill> SkillList { get; private set; }

    private void Awake()
    {
        Init();
        InitSkillList();
    }

    // 초기화 메서드
    public void Init()
    {
        Name = _unit.InitialName;
        Stat = _unit.InitialStat;
    }

    // 스킬 초기화 메서드
    public void InitSkillList()
    {
        if(SkillList == null)
            SkillList = new List<ISkill>();

        string[] skillName = { _unit.SkillList[0].Name, _unit.SkillList[1].Name };
        int[] coinCount = { _unit.SkillList[0].CoinCount, _unit.SkillList[1].CoinCount };
        int[] basicSkillValue = { _unit.SkillList[0].BasicSkillValue, _unit.SkillList[1].BasicSkillValue };
        int[] coinValue = { _unit.SkillList[0].CoinValue, _unit.SkillList[1].CoinValue };

        SkillList.Add(new FaustSkill1(skillName[0], coinCount[0], basicSkillValue[0], coinValue[0]));
        SkillList.Add(new FaustSkill1(skillName[1], coinCount[1], basicSkillValue[1], coinValue[1]));
    }

    // 데미지를 입는 메서드
    public void TakeDamage(int damage)
    {
    }

    
}