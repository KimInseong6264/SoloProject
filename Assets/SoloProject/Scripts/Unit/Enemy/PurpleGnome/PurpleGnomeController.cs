using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PurpleGnomeView))]
public class PurpleGnomeController : MonoBehaviour, IUnitInteractive, IClickable
{
    [SerializeField] private UnitDataSO _unit;
    public PurpleGnomeView View { get; private set; }

    public Unit UnitModel { get; private set; }

    private void Awake()
    {
        View = GetComponent<PurpleGnomeView>();
        UnitModel = new PurpleGnomeModel(_unit, this);
        UnitModel.SetPos(transform);
        View.GetHpBar(UnitModel.Stat.HP, _unit.InitialStat.HP);
    }

    private void Start()
    {
        // 스킬 애니메이션과 스킬 모션(상태패턴)을 연결
        SetSkillMotion();
        SetEnemyBattle();

        UnitModel.OnChangeHp += View.GetHpBar;
        BattleManager.Instance.Damage.OnEndDamageStep += SetEnemyBattle;
    }

    private void Update()
    {
        UpdateState();


        if (UnitModel.Stat.HP == 0)
        {
            GameManager.Instance.Scene.Load(2);
        }
    }


    // 상태 변환 메서드

    // 스킬 애니메이션을 스킬 모션에 연결하는 메서드
    private void SetSkillMotion()
    {
        foreach (var skillList in UnitModel.SkillList)
        {
            skillList.OnSkillMotion += View.OnSkillAni;
        }
    }

    public void SetState(State state) => UnitModel.SetState(state);

    private void UpdateState()
    {
        if (UnitModel.CurrentState == UnitModel.StateList[State.Idle] ||
            UnitModel.CurrentState == UnitModel.StateList[State.Attack] ||
            UnitModel.CurrentState == UnitModel.StateList[State.Clash])
            return;

        UnitModel.CurrentState.Update();
    }

    public void OnCklick() => 
        BattleManager.Instance.BattleUnit[UnitType.Enemy] = UnitModel;



    public void SetEnemyBattle()
    {
        int i = UnityEngine.Random.Range(0, 2);
        BattleManager.Instance.SetBattle(UnitType.Enemy, UnitModel, UnitModel.SkillList[i]);
    }

}
