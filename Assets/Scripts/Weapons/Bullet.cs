using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    [SerializeField] private float _timeDisable = 3f;
    [SerializeField] private ParticleSystem _particleSystem;

    private float _damage;
    
    public float Damage => _damage;

    public void init(float speed, float damage)
    {
        _speed = speed;
        _damage = damage;
        StartCoroutine(StartBoomCountdown());
    }

    protected void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    protected void Move()
    {
        
    }

    private IEnumerator StartBoomCountdown()
    {
        yield return new WaitForSeconds(_timeDisable);
        if (_particleSystem)
        {
            ParticleSystem particleSystem = Instantiate(_particleSystem, transform.position, Quaternion.identity);
            particleSystem.Play();
        }
        gameObject.SetActive(false);
    }
}
