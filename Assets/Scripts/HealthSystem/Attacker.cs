using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private LayerMask _enemyLayer;

    private ContactFilter2D _filter;
    private BoxCollider2D _attackCollider;
    private List<Collider2D> _overlapResults = new List<Collider2D>();

    public LayerMask EnemyLayer => _enemyLayer;
    public BoxCollider2D AttackCollider { get; private set; }

    private void Awake()
    {
        _attackCollider = GetComponent<BoxCollider2D>();

        _filter.SetLayerMask(_enemyLayer);
        _filter.useLayerMask = true;

        AttackCollider = _attackCollider;
    }

    public void TryAttack()
    {
        _overlapResults.Clear();

        int countColliders = Physics2D.OverlapCollider(_attackCollider, _filter, _overlapResults);

        if (countColliders > 0)
        {
            for (int i = 0; i < countColliders; i++)
                Attack(_overlapResults[i]);
        }
    }

    private void Attack(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }
}