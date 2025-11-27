using UnityEngine;
using UnityEngine.UI;

public class BattleSelectedUI : MonoBehaviour
{
    [SerializeField] private Text[] _playerText;
    [SerializeField] private Text[] _enemyText;
    private Unit _player;
    private Unit _enemy; 
    private Skill _playerSkill;
    private Skill _enemySkill;

    private void Update()
    {
        _player = BattleManager.Instance.BattleUnit[UnitType.Player];
        _enemy = BattleManager.Instance.BattleUnit[UnitType.Enemy];
        _playerSkill = BattleManager.Instance.BattleSkill[UnitType.Player];
        _enemySkill = BattleManager.Instance.BattleSkill[UnitType.Enemy];

        if (BattleManager.Instance.BattleUnit[UnitType.Player] != null)
            _playerText[0].text = _player.Name;

        if (BattleManager.Instance.BattleSkill[UnitType.Player] != null)
            _playerText[1].text = $"{_playerSkill.SkillName}\n코인수: {_playerSkill.CoinCount}\n코인값: {_playerSkill.CoinValue}";

        if (BattleManager.Instance.BattleUnit[UnitType.Enemy] != null)
            _enemyText[0].text = _enemy.Name;

        if(BattleManager.Instance.BattleSkill[UnitType.Enemy] != null)
            _enemyText[1].text = $"{_enemySkill.SkillName}\n코인수: {_enemySkill.CoinCount}\n코인값: {_enemySkill.CoinValue}";
    }

    public void SetPlayerSkill(int i)
    {

        BattleManager.Instance.SetBattle(
            UnitType.Player,
            BattleManager.Instance.SelectedPlayer[0],
            BattleManager.Instance.SelectedPlayer[0].SkillList[i]
            );
    }

    public void SetEnemySkill(int i)
    {
        BattleManager.Instance.SetBattle(
            UnitType.Enemy,
            BattleManager.Instance.SelectedPlayer[0],
            BattleManager.Instance.SelectedPlayer[0].SkillList[i]
            );
    }
}
