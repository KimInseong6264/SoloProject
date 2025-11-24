using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(FaustView))]
public class FaustControler : MonoBehaviour, IClickable
{
    [SerializeField] private UnitData _unit;
    public FaustView FaustView { get; private set; }

    private FaustModel _faustModel;
    private Dictionary<State, IUnitState> _stateList;
    private IUnitState _currentState;

    private void Awake()
    {
        FaustView = GetComponent<FaustView>();
        _faustModel = new FaustModel(_unit);
        
        // 상태패턴 세팅
        _stateList = new Dictionary<State, IUnitState>();
        _stateList.Add(State.Idle, new FaustIdle(this));
        _stateList.Add(State.Move, new FaustMove(this));
        _stateList.Add(State.Clash, new FaustClash(this));
        _stateList.Add(State.Attack, new FaustAttack(this));
        SetState(State.Idle);
    }

    private void Start()
    {
        // 스킬 애니메이션과 스킬 모션(상태패턴)을 연결
        SetSkillMotion();
    }

    private void Update()
    {
        _currentState.Update();
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
        foreach (var skillList in _faustModel.SkillList)
        {
            Debug.Log(skillList + "에 구독");
            skillList.OnSkillMotion += FaustView.OnSkillAni;
        }
    }

    public void OnCklick()
    {
        BattleManager.Instance.Clash.BattleUnit[(int)UnitType.Player] = _faustModel;
    }
}
