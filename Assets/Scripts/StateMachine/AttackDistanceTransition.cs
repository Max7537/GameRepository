using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackDistanceTransition : Transition
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 1;

    private void Start()
    {
        _target = FindObjectOfType<PlayerAttack>().transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) < _distance)
        {
            _needTransit = true;
        }
    }
}
