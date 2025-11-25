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
        CoinSystem playerCoin = BattleManager.Instance.PlayerCoin;

        _playerCoin.text = "플레이어 코인: " + playerCoin.ClashPower;

    }
    public void GetEnemyToss()
    {
        CoinSystem enemyCoin = BattleManager.Instance.PlayerCoin;
        _enemyCoin.text = "에너미 코인: " + enemyCoin.ClashPower;
    }
}
