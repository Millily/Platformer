using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypoint = 0;
    private float _distanceToTarget = 0.1f;

    public void Move()
    {
        if (_waypoints == null || _waypoints.Length == 0) return;

        Vector3 targetPosition = _waypoints[_currentWaypoint].position;
        targetPosition.y = transform.position.y;

        if (transform.position.IsEnoughClose(targetPosition, _distanceToTarget))
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

            targetPosition = _waypoints[_currentWaypoint].position;
            targetPosition.y = transform.position.y;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}