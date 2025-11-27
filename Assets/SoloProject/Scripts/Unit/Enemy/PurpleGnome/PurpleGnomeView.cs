using UnityEngine;
using UnityEngine.UI;

public class PurpleGnomeView : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private Text _hpText;

    public Animator Ani => _animator;

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

    public void OnIdleAni() => _animator.SetInteger("Behaviour", 0);
    public void OnMoveAni() => _animator.SetInteger("Behaviour", 1);
    public void OnHurtAni() => _animator.SetInteger("Behaviour", 2);
    public void OnSkillAni(int i) => _animator.SetTrigger("Skill" + i);
    public void OnClashAni() => _animator.SetTrigger("Clash");
}
