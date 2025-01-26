using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;

    private void Start()
    {
        SetState(_firstState);
    }

    private void SetState(State state)
    {
        if (_currentState)
        {
            _currentState.Exit();
        }
        _currentState = state;
        if (_currentState)
        {
            _currentState.Enter();
        }
    }

    private void Update()
    {
        if (!_currentState)
        {
            return;
        }
        else
        {
            State nextState = _currentState.CheckState();
            if (nextState)
            {
                SetState(nextState);
            }
        }
    }
}
