using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    public static event Action EnemyDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            _health -= bullet.Damage;
            if (_health <= 0)
            {
                EnemyDestroyed?.Invoke();
                Destroy(gameObject);
            }
        }
        collision.gameObject.SetActive(false);
    }
}
