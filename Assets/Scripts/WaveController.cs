using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves = new List<Wave>();
    [SerializeField] private Wave _currentWave;
    [SerializeField] private float _waveOffset;
    [SerializeField] private PlayerCoins _playerCoins;

    private int _currentWaveIndex;

    public Action Win;

    private void OnEnable()
    {
        EnemyHealth.EnemyDestroyed += CheckForEnemiesLeft;
    }

    private void OnDisable()
    {
        EnemyHealth.EnemyDestroyed -= CheckForEnemiesLeft;
    }

    private void Start()
    {
        _currentWave = _waves[0];
        SpawnEnemies();
    }

    private void SetNewWave()
    {
        _currentWaveIndex++;

        if (_currentWaveIndex >= _waves.Count)
        {
            Win?.Invoke();
            StopAllCoroutines();
        }
        else
        {
            _currentWave = _waves[_currentWaveIndex];
        }
    }

    private void CheckForEnemiesLeft()
    {
        if (_currentWaveIndex >= _waves.Count)
        {
            return;
        }
        else
        {
            _currentWave._enemies.Remove(_currentWave._enemies[0]);
            if (_currentWave._enemies.Count < 1)
            {
                _playerCoins.GetReward(_currentWave._reward);
                SetNewWave();
                SpawnEnemies();
            }
        }
    }

    private void SpawnEnemies()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }
    
    private IEnumerator SpawnEnemiesCoroutine()
    {
        for (int i = 0; i < _currentWave._count; i++)
        {
            yield return new WaitForSeconds(_currentWave._spawnOffset);
            EnemyHealth enemy = Instantiate(_currentWave._enemies[UnityEngine.Random.Range(0, _currentWave._enemies.Count)]);
        }
    }

}

[Serializable] public class Wave
{
    [SerializeField] public List<EnemyHealth> _enemies = new List<EnemyHealth>();
    [SerializeField] public float _spawnOffset;
    [SerializeField] public int _count;
    [SerializeField] public float _reward;
}
