using System.Collections.Generic;
using UnityEngine;

public class LeeSang : MonoBehaviour //, ISkillable
{
    [SerializeField] private Unit _unit;

    [SerializeField] public List<Skill> _skillList;

    private void Awake()
    {

    }
}
