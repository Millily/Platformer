using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class Mover : MonoBehaviour
{
    private Flipper _flipper;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    public void MoveTo(Vector3 targetPosition, float speed)
    {
        _flipper.CheckFlip(targetPosition.x - transform.position.x);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}