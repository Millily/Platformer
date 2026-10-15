using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private float _speedIncrementer = 2;

    public void Chase(Mover mover, EnemyVision enemyVision, float speed)
    {
        if (enemyVision.Player == null)
            return;

        Vector3 target = enemyVision.Player.transform.position;
        target.y = transform.position.y;

        mover.MoveTo(target, speed + _speedIncrementer);
    }
}