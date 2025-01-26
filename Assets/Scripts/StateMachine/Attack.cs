using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private GameObject _weaponContainer;

    private PlayerAttack _player;
    private float _elapsedTime;

    public static event Action Attacked;

    private void Start()
    {
        _player = FindObjectOfType<PlayerAttack>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime <= _attackSpeed / 2)
        {
            _weaponContainer.transform.eulerAngles = new Vector3(0, 0, (_elapsedTime) / (_attackSpeed / 2) * -45);
        }
        else if (_elapsedTime > _attackSpeed / 2)
        {
            _weaponContainer.transform.eulerAngles = new Vector3(0, 0, (_attackSpeed / 2) / _elapsedTime * -45);
        }
        
        if (_elapsedTime >= 1 / _attackSpeed)
        {
            _player.HealthPoints -= _damage;
            _elapsedTime = 0;
            Attacked?.Invoke();
        }
    }
}
