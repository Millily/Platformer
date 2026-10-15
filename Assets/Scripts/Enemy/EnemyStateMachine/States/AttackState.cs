using UnityEngine;

public class AttackState : State
{
    private float _attackCooldown;
    private float _cooldownDuration;
    private Enemy _enemy;

    public AttackState(StateMachine stateMachine, Enemy enemy, float cooldownDuration) : base(stateMachine)
    {
        _enemy = enemy;
        _cooldownDuration = cooldownDuration;
    }

    public override void Enter()
    {
        _attackCooldown = 0f;
    }

    protected override void OnUpdate()
    {
        if (_attackCooldown > 0)
            _attackCooldown -= Time.deltaTime;

        if (_attackCooldown <= 0)
        {
            _enemy.OnAttack();
            _attackCooldown = _cooldownDuration;
        }
    }
}