using UnityEngine;
using UnityEngine.UI;

public class FaustView : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private Text _hpText;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetHpBar(float hp, float maxHp)
    {
        _hpText.text = hp.ToString();
        _scrollbar.size = hp / maxHp;
    }

    public void UpdateHp(int hp)
    {
        float HP = (float)hp;
        _scrollbar.size = HP / HP;
    }

    public void OnMoveAni(float distance)
    {
        bool IsMove = distance > 1f;
        _animator.SetBool("Distance", IsMove);
    }

    public void OnSkillAni(int i) => _animator.SetTrigger("Skill" + i);

    public void OnClashAni() => _animator.SetTrigger("Clash");
    
    public void OnIdleAni() => _animator.SetBool("Distance", false);
}
