using System;
using System.Collections.Generic;

public abstract class State
{
    protected StateMachine _stateMachine;
    private readonly List<Transition> _transitions = new();

    public State(StateMachine stateMachine) 
    { 
        _stateMachine = stateMachine; 
    }

    public virtual void Enter() { }

    public virtual void Update()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.TryTransit(out State nextState) == false)
                continue;

            _stateMachine.ChangeState(nextState);
            return;
        }

        OnUpdate();
    }

    public virtual void FixedUpdate() { }

    public virtual void Exit() { }

    public void AddTransition(Transition transition)
    {
        if (transition == null)
            throw new ArgumentNullException(nameof(transition));

        if (_transitions.Contains(transition))
            throw new ArgumentException(nameof(transition));

        _transitions.Add(transition);
    }

    protected virtual void OnUpdate()
    {
    }
}