using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _force = 0.5f;

    public void Jump(Rigidbody2D rigidbody2D, bool isGrounded)
    {
        if (isGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }
}