using UnityEngine;

public class FaustMove : IUnitState
{
    private FaustControler _faust;
    private Transform _transform;
    private float _maxDistance = 3f;
    private float _speed = 8f;

    public FaustMove(FaustControler faust)
    {
        _faust = faust;
        _transform = faust.transform;
    }

    public void Enter()
    {
        float distance = Vector3.Magnitude(GetDirection());

        _faust.View.OnMoveAni(distance);
    }

    public void Exit()
    {
        Debug.Log("파우스트 이동 종료");
    }

    public void Update()
    {
        Vector3 dir = GetDirection();
        SetMoveing(dir);

         float distance = Vector3.SqrMagnitude(dir);
        if (distance < _maxDistance)
            _faust.SetState(State.Clash);
    }

    private Vector3 GetDirection()
    {
        Vector3 playerPos = BattleManager.Instance.BattleUnit[UnitType.Player].CurrentPos.position;
        Vector3 enemyPos = BattleManager.Instance.BattleUnit[UnitType.Enemy].CurrentPos.position;

        return enemyPos - playerPos;
    }

    private void SetMoveing(Vector3 direction)
    {
        _transform.Translate
            (direction.normalized * Time.deltaTime * _speed);
    }
}