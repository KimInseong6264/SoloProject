using UnityEngine;

public class PurpleGnomeView : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnMoveAni(float distance)
    {
        bool IsMove = distance > 1f;
        _animator.SetBool("Distance", IsMove);
    }

    public void OnSkillAni(int i)
    {
        _animator.SetTrigger("Skill" + i);
    }

    public void OnClashAni()
    {
        _animator.SetTrigger("Clash");
    }
    
    public void OnIdleAni()
    {
        _animator.SetBool("Distance", false);
    }
}
