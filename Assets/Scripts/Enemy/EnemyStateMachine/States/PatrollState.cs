public class PatrollState : State
{
    private Enemy _enemy;

    public PatrollState(StateMachine stateMachine, Enemy enemy) : base(stateMachine) 
    {
        _enemy = enemy;
    }

    protected override void OnUpdate()
    {
        _enemy.OnPatroll();
    }
}