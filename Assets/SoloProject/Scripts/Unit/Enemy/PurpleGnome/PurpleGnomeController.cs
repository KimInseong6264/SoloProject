using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PurpleGnomeView))]
public class PurpleGnomeController : MonoBehaviour, IUnitInteractive, IClickable
{
    [SerializeField] private UnitDataSO _unit;
    public PurpleGnomeView View { get; private set; }

    public Unit UnitModel { get; private set; }

    private Dictionary<State, IUnitState> _stateList;
    private IUnitState _currentState;

    // ClashSystem의 OnBattleStart에 SetState가 들어있으면 true
    // 중복되게 구독하지 않도록 방지
    private bool _isBattle;

    private void Awake()
    {
        View = GetComponent<PurpleGnomeView>();
        UnitModel = new PurpleGnomeModel(_unit, this);
        UnitModel.SetPos(transform);

        // 상태 패턴 연결
        _stateList = UnitModel.StateList;
        _currentState = UnitModel.CurrentState;
    }

    private void Start()
    {
        // 스킬 애니메이션과 스킬 모션(상태패턴)을 연결
        SetSkillMotion();
    }

    private void Update()
    {
        OnMove();
    }


    // 상태 변환 메서드
    public void SetState(State state)
    {
        _currentState?.Exit();
        _currentState = _stateList[state];
        _currentState.Enter();
    }

    // 스킬 애니메이션을 스킬 모션에 연결하는 메서드
    private void SetSkillMotion()
    {
        foreach (var skillList in UnitModel.SkillList)
        {
            skillList.OnSkillMotion += View.OnSkillAni;
        }
    }

    private void OnMove()
    {
        if (_currentState == _stateList[State.Move])
        {
            _currentState.Update();
            transform.position = UnitModel.CurrentPos.position;
        }
    }

    public void OnCklick()
    {
        BattleManager.Instance.BattleUnit[UnitType.Enemy] = UnitModel;

        if (!_isBattle)
        {
            ClashSystem clash = BattleManager.Instance.Clash;
            clash.OnBattleStart += SetState;
            _isBattle = true;
        }
    }
}
