using UnityEngine;

public class EnemyStateMachineFactory: MonoBehaviour
{
    public StateMachine Create(Enemy enemy)
    {
        StateMachine stateMachine = new StateMachine();

        PatrollState patrollState = new PatrollState(stateMachine, enemy);
        ChaseState chaseState = new ChaseState(stateMachine, enemy);
        AttackState attackState = new AttackState(stateMachine, enemy, enemy.CooldownDuration);

        ToPatrollStateTransition toPatroll = new ToPatrollStateTransition(patrollState, enemy);
        ToChaseStateTransition toChase = new ToChaseStateTransition(chaseState, enemy);
        ToAttackStateTransition toAttack = new ToAttackStateTransition(attackState, enemy);
        ToChaseFromAttackTransition toChaseFromAttack = new ToChaseFromAttackTransition(chaseState, enemy);

        patrollState.AddTransition(toChase);

        chaseState.AddTransition(toAttack);
        chaseState.AddTransition(toPatroll);

        attackState.AddTransition(toChaseFromAttack);
        attackState.AddTransition(toPatroll);

        stateMachine.ChangeState(patrollState);

        return stateMachine;
    }
}