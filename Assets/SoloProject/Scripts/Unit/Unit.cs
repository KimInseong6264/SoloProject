using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Scriptable Objects/Unit")]
public class Unit : ScriptableObject
{

    [SerializeField] private string _name;
    [SerializeField] private Stat _stat;
    [SerializeField] private List<Skill> _skillList;
    


    public void Init(string name, int hp, int att, int defense)       //스텟을 부여하는 생성자
    {
        _name = name;
        _stat.HP = hp;
        _stat.Att = att;
        _stat.Def = defense;
    }

    [System.Serializable]
    public struct Stat
    {
        public int HP;
        public int Att;
        public int Def;
    }
}


    //private List<int> _tossList;        //각 유닛마다 코인토스했을 때의 결과를 임시로 담아놓는 리스트

    //코인토스 로직        
    //public void ClashCoinToss(Unit unit, Skill skill, int y)  //유닛이 코인토스를 진행하는 메서드
    //{                                                           //y는 코인토스 결과를 콘솔에 출력할 때 커서의 y값을 결정하는 값
    //    Coin coin = new Coin();
    //    coin.Toss(unit, skill, y);

    //}