using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _force = 0.8f;

    public void Jump(Rigidbody2D rigidbody2D)
    {
        if (_groundChecker.IsGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }
}