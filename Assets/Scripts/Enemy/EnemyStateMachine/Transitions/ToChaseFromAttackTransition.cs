using UnityEngine;

public class ToChaseFromAttackTransition : Transition
{
    private Enemy _enemy;

    public ToChaseFromAttackTransition(State nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.EnemyVision.IsPlayerDetected && _enemy.EnemyVision.IsPlayerInAttackRange == false;
    }
}