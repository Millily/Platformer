using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyVisual : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _previousX;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _previousX = transform.position.x;
    }

    private void LateUpdate()
    {
        float deltaX = transform.position.x - _previousX;

        if (deltaX > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (deltaX < 0)
        {
            _spriteRenderer.flipX = false;
        }

        _previousX = transform.position.x;
    }
}