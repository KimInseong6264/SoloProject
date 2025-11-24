using UnityEngine;
using UnityEngine.UI;

public class BattleSeletUI : MonoBehaviour
{
    [SerializeField] private Text _playerText;
    [SerializeField] private Text _enemyText;

    private void Update()
    {
        
    }

    public void SetPlayerText()
    {
        _playerText.text = "플레이어를 선택해주세요";
    }

    public void SetEnemyText()
    {
        _enemyText.text = "에너미를 선택해주세요";
    }
}
