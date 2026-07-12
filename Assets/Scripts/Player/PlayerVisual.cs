using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Flipper _flipper;

    public readonly int Speed = Animator.StringToHash(nameof(Speed));

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetMovementState(float moveDirection)
    {
        _flipper.ChekFlip(moveDirection);
        _animator.SetFloat(Speed, Mathf.Abs(moveDirection));
    }
}