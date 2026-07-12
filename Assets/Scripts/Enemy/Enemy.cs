using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(Flipper))]
public class Enemy : MonoBehaviour
{
    EnemyMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
    }

    private void FixedUpdate()
    {
        _movement.Move();
    }
}