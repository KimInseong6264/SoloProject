using UnityEngine;

public class FaustMove : IUnitState
{
    private FaustControler _faust;

    public FaustMove(FaustControler faust)
    {
        _faust = faust;
    }

    public void Enter()
    {
        //_faust.FaustView.OnMoveAni();
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }
}