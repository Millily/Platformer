using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class PlayerVisual : MonoBehaviour
{
    private const string Speed = "Speed";

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetMovementState(float moveDirection)
    {
        if (moveDirection < 0)
            _spriteRenderer.flipX = true;
        else if (moveDirection > 0)
            _spriteRenderer.flipX = false;

        _animator.SetFloat(Speed, Mathf.Abs(moveDirection));
    }
}