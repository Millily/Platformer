public class ChaseState : State
{
    private Enemy _enemy;

    public ChaseState(StateMachine stateMachine, Enemy enemy) : base(stateMachine)
    {
        _enemy = enemy;
    }

    protected override void OnUpdate()
    {
        _enemy.OnChase();
    }
}