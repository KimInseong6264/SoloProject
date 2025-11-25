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
    }

    private void Start()
    {
        // 스킬 애니메이션과 스킬 모션(상태패턴)을 연결
        SetSkillMotion();
    }

    private void Update()
    {
        Debug.LogWarning(UnitModel.CurrentState);
        OnMove();
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

    private void OnMove()
    {
        if (UnitModel.CurrentState == UnitModel.StateList[State.Move])
        {
            UnitModel.CurrentState.Update();
        }
    }

    public void OnCklick() => 
        BattleManager.Instance.SetBattle(UnitType.Player, UnitModel);
}
