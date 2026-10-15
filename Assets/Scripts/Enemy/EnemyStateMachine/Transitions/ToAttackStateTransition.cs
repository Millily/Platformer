public class ToAttackStateTransition : Transition
{
    private Enemy _enemy;

    public ToAttackStateTransition(State nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.EnemyVision.IsPlayerInAttackRange;
    }
}