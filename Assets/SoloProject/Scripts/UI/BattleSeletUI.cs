using UnityEngine;
using UnityEngine.UI;

public class BattleSeletUI : MonoBehaviour
{
    [SerializeField] private Text[] _playerText;
    [SerializeField] private Text[] _enemyText;
    Unit _player;
    Unit _enemy; 
    Skill _playerSkill;
    Skill _enemySkill;

    private void Update()
    {
        _player = BattleManager.Instance.BattleUnit[UnitType.Player];
        _enemy = BattleManager.Instance.BattleUnit[UnitType.Enemy];
        _playerSkill = BattleManager.Instance.BattleSkill[UnitType.Player];
        _enemySkill = BattleManager.Instance.BattleSkill[UnitType.Enemy];

        if (BattleManager.Instance.BattleUnit[UnitType.Player] != null)
            _playerText[0].text = _player.Name;

        if (BattleManager.Instance.BattleSkill[UnitType.Player] != null)
            _playerText[1].text = $"{_playerSkill.SkillName}, 코인수: {_playerSkill.CoinCount}, 코인값: {_playerSkill.CoinValue}";

        if (BattleManager.Instance.BattleUnit[UnitType.Enemy] != null)
            _enemyText[0].text = _enemy.Name;

        if(BattleManager.Instance.BattleSkill[UnitType.Enemy] != null)

            _enemyText[1].text = $"{_enemySkill.SkillName}, 코인수: {_enemySkill.CoinCount}, 코인값: {_enemySkill.CoinValue}";
    }

    public void SetPlayerSkill(int i)
    {
        BattleManager.Instance.SetBattle(
            UnitType.Player,
            skill: BattleManager.Instance.BattleUnit[UnitType.Player].SkillList[i]
            );
    }

    public void SetEnemySkill(int i)
    {
        BattleManager.Instance.SetBattle(
            UnitType.Enemy,
            skill: BattleManager.Instance.BattleUnit[UnitType.Enemy].SkillList[i]
            );
    }
}
