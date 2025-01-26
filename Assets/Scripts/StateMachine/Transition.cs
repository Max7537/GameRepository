using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    protected bool _needTransit;

    public State NextState => _nextState;

    public bool NeedTransit => _needTransit;

    public void DisableTransition()
    {
        _needTransit = false;
    }
}
