using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private bool _isFacingRight = true;

    public void CheckFlip(float direction)
    {
        if (direction > 0 && !_isFacingRight || direction < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.rotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);
    }
}