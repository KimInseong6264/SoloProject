
public class PurpleGnomeIdle : IUnitState
{
    private PurpleGnomeController _purpleGnome;

    public PurpleGnomeIdle(PurpleGnomeController purpleGnome)
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