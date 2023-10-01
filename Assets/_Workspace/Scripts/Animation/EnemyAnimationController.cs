using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;

    private int MOVE = Animator.StringToHash("isMove");
    private int ATTACK = Animator.StringToHash("isAttack");

    public void Init()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack(bool isActive)
    {
        _animator.SetBool(ATTACK, isActive);
    }

    public void Move(bool isActive)
    {
        _animator.SetBool(MOVE, isActive);
    }
}
