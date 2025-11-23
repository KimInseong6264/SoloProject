
public class FaustIdle : IUnitState
{
    private FaustControler _faust;

    public FaustIdle(FaustControler faust)
    {
        _faust = faust;
    }

    public void Enter()
    {
        _faust.FaustView.OnIdleAni();
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}