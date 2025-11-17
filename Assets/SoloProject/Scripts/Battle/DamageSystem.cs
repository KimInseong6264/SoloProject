using UnityEngine;

public class DamageSystem : MonoBehaviour
{

    private CoinSystem _CoinList = new();

    private void OnEnable()
    {
        BattleManager.Instance.Clash.OnDamageStep += GetDamageStep;
    }

    private void GetDamageStep(UnitType unit)
    {
        ClashSystem clash = BattleManager.Instance.Clash;



    }
}
