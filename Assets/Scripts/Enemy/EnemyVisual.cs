using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyVisual : MonoBehaviour
{
    public readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAttackState()
    {
        _animator.SetTrigger(IsAttacking);
    }
}