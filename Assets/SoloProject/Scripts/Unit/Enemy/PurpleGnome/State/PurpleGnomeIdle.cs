
public class PurpleGnomeIdle : IUnitState
{
    private PurpleGnomeControler _purpleGnome;

    public PurpleGnomeIdle(PurpleGnomeControler purpleGnome)
    {
        _purpleGnome = purpleGnome;
    }

    public void Enter()
    {
        _purpleGnome.View.OnIdleAni();
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}