using UnityEngine;

public class FaustView : MonoBehaviour
{
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnMove()
    {
        
    }

    public void OnSkill(ISkill skill)
    {

    }

    public void OnClash()
    {

    }


}
