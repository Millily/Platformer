using UnityEngine;

public class StateMachine
{
    private State _currentState;

    public void ChangeState(State newState)
    {
        if (newState == null || _currentState == newState) return;

        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter();
    }

    public void Update()
    {
        Debug.Log(_currentState.GetType());
        _currentState?.Update();
    }
}