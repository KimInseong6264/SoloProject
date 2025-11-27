using UnityEngine;
using UnityEngine.UI;

public class ClashUI : MonoBehaviour
{
    [SerializeField] private Text _playerCoin;
    [SerializeField] private Text _enemyCoin;


    private void Update()
    {
        GetPlayerToss();
        GetEnemyToss();
    }

    public void GetPlayerToss()
    {
        BattleManager system = BattleManager.Instance;

        if (system.BattleSkill[UnitType.Player] == null)
            return;

        int playerClash = system.BattleSkill[UnitType.Player].BasicSkillValue + system.PlayerCoin.ClashPower;

        _playerCoin.text = "기본 위력: " + playerClash;

    }
    public void GetEnemyToss()
    {
        BattleManager system = BattleManager.Instance;

        if (system.BattleSkill == null)
            return;

        int enemyClash = system.BattleSkill[UnitType.Enemy].BasicSkillValue + system.EnemyCoin.ClashPower;

        CoinSystem enemyCoin = BattleManager.Instance.EnemyCoin;
        _enemyCoin.text = "기본 위력: " + enemyClash;
    }
}
