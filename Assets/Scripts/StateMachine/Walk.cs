using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Translate(-_speed, 0, 0);
    }
}
