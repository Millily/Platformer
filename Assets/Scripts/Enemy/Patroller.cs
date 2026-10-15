using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypoint = 0;
    private float _distanceToTarget = 0.1f;

    public void Patroll(Mover mover, float speed)
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

        mover.MoveTo(targetPosition, speed);
    }
}