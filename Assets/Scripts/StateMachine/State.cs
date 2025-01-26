using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions = new List<Transition>();

    public void Enter()
    {
        enabled = true;
        for (int i = 0; i < _transitions.Count; i++)
        {
            _transitions[i].enabled = true;
        }
    }

    public void Exit()
    {
        enabled = false;
        for (int i = 0; i < _transitions.Count; i++)
        {
            _transitions[i].enabled = false;
            _transitions[i].DisableTransition();
        }
    }

    public State CheckState()
    {
        for (int i = 0; i < _transitions.Count; i++)
        {
            if (_transitions[i].NeedTransit)
            {
                return _transitions[i].NextState;
            }
        }
        return null;
    }
}
