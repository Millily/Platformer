using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    public bool IsPlayerDetected { get; private set; }
    public bool IsPlayerInAttackRange { get; private set; }
    public Player Player { get; private set; }

    private void Update()
    {
        Detect();
    }

    private void Detect()
    {
        Collider2D target = Physics2D.OverlapArea(_startPoint.position, _endPoint.position, _playerLayer);

        if (target != null)
        {
            Player = target.gameObject.GetComponent<Player>();
        }
        else
        {
            Player = null;
        }

        IsPlayerDetected = Player != null;

        if (IsPlayerDetected)
        {
            float distance = Vector2.Distance(transform.position, Player.transform.position);
            Debug.Log($"Расстояние между центрами: {distance}");
            IsPlayerInAttackRange = distance < 1.5f;
        }
    }
}