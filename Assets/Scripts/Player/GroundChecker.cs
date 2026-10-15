using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _radius = 1.0f;
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
       IsGrounded = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
    }
}