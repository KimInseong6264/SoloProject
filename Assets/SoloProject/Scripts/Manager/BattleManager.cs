using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private CoinSystem _coinSystem;

    private void Awake()
    {
        _coinSystem = GetComponent<CoinSystem>();
    }
}
