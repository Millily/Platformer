using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    public void Move(float direction, Rigidbody2D rigidbody2D)
    {
        rigidbody2D.velocity = new Vector2 (direction * _speed, rigidbody2D.velocity.y);
    }
}