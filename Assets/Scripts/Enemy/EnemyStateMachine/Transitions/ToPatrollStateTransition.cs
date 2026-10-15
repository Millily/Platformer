public class ToPatrollStateTransition : Transition
{
    private Enemy _enemy;

    public ToPatrollStateTransition(State nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        if (_enemy.EnemyVision.IsPlayerDetected == false)
            return true;

        return false;
    }
}