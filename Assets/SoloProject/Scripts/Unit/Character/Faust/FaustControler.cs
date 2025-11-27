using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(FaustView))]
public class FaustControler : MonoBehaviour, IUnitInteractive, IClickable
{
    [SerializeField] private UnitDataSO _unit;
    public FaustView View { get; private set; }
    public Unit UnitModel { get; private set; }

    private void Awake()
    {
        View = GetComponent<FaustView>();
        UnitModel = new FaustModel(_unit, this);
        UnitModel.SetPos(transform);
        View.GetHpBar(UnitModel.Stat.HP, _unit.InitialStat.HP);


        BattleManager.Instance.SetSelectedList(UnitModel);       // 도감을 만들어서 도감에서 먼저 선택 후에 받아오는 형식으로 변경해야 함
        
    }

    private void Start()
    {
        // 스킬 애니메이션과 스킬 모션(상태패턴)을 연결
        SetSkillMotion();

        UnitModel.OnChangeHp += View.GetHpBar;
        
    }

    private void Update()
    {
        UpdateState();

        if(UnitModel.Stat.HP == 0)
            GameManager.Instance.Scene.Load(3);
    }

    // 스킬 애니메이션을 스킬 모션에 연결하는 메서드
    private void SetSkillMotion()
    {
        foreach (var skillList in UnitModel.SkillList)
        {
            skillList.OnSkillMotion += View.OnSkillAni;
        }
    }

    public void SetState(State newState) => UnitModel.SetState(newState);

    private void UpdateState()
    {
        if (UnitModel.CurrentState == UnitModel.StateList[State.Idle] || 
            UnitModel.CurrentState == UnitModel.StateList[State.Attack] ||
            UnitModel.CurrentState == UnitModel.StateList[State.Clash])
            return;

        UnitModel.CurrentState.Update();
    }

    public void OnCklick() => 
        BattleManager.Instance.SetBattle(UnitType.Player, UnitModel);
}
