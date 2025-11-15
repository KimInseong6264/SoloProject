using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Unit")]
public class Unit : ScriptableObject
{

    [SerializeField] private string _name;
    [SerializeField] private Stat _stat;
    [SerializeField] private List<Skill> _skillList;

    [System.Serializable]
    public struct Stat
    {
        public int HP;
        public int Att;
        public int Def;
    }
}