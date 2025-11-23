using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FaustView))]
public class FaustControler : MonoBehaviour
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

        _stateList = new Dictionary<State, IUnitState>();
        _stateList.Add(State.Idle, new FaustIdle(this));
        _stateList.Add(State.Move, new FaustMove(this));
        _stateList.Add(State.Clash, new FaustClash(this));
        _stateList.Add(State.Attack, new FaustAttack(this));
        SetState(State.Idle);
    }

    public void SetState(State state)
    {
        _currentState?.Exit();
        _currentState = _stateList[state];
        _currentState.Enter();
    }

    private void Update()
    {
        _currentState.Update();
    }
}
