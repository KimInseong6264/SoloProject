using UnityEngine;
using UnityEngine.UIElements;

public class PurpleGnomeMove : IUnitState
{
    private PurpleGnomeController _purpleGnome;
    private Transform _transform;
    float _distance = 0f;
    private float _speed = 8f;

    public PurpleGnomeMove(PurpleGnomeController purpleGnome)
    {
        _purpleGnome = purpleGnome;
    }

    public void Enter()
    {
        _distance = Vector3.Magnitude(GetDirection());

        _purpleGnome.View.OnMoveAni(_distance);
    }

    public void Exit()
    {
        Debug.Log("노움 이동 종료");
    }

    public void Update()
    {
        Vector3 dir = GetDirection();
        SetMoveing(dir);
        _distance = Vector3.SqrMagnitude(dir);


        if (_distance < 2f)
            _purpleGnome.SetState(State.Clash);

    }

    // 유닛 사이의 거리 구하기
    private Vector3 GetDirection()
    {
        Vector3 playerPos = BattleManager.Instance.BattleUnit[UnitType.Player].CurrentPos.position;
        Vector3 enemyPos = BattleManager.Instance.BattleUnit[UnitType.Enemy].CurrentPos.position;

        return playerPos- enemyPos;
    }

    // 저장된 트랜스폼값 이동(Player인지,Enemy인지 확인)
    // Controller의 포지션값에 넣어줘야 함
    private void SetMoveing(Vector3 direction)
    {
        _transform = BattleManager.Instance.BattleUnit[UnitType.Enemy].CurrentPos;

        _transform.Translate
            (direction.normalized * Time.deltaTime * _speed);
    }
}