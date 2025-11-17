using Unity.VisualScripting;
using UnityEngine;

// 합 이후 데미지 관련 클래스
public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public ClashSystem Clash { get; private set; }
    public DamageSystem Damage { get; private set; }

    private void Awake()
    {
        Instance = GetComponent<BattleManager>();

        Clash = GetComponent<ClashSystem>();
        Damage = GetComponent<DamageSystem>();
    }

}
