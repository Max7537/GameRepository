using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _shootDelay;
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected float _bulletSpeed;
    [SerializeField] protected float _amountOfAllBullets;
    [SerializeField] protected float _amountOfbullets;
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] private Image _rechargeImage;
    [SerializeField] private float _rechargeSpeed;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _price;
    [SerializeField] private string _name;

    [SerializeField] public WeaponType _weaponType;
    [SerializeField] public float _maxAmoutOfBullets;

    public float Price => _price;
    public string Name => _name;
    public float AmountOfAllBullets => _amountOfAllBullets;
    public float AmountOfBullets => _amountOfbullets;

    protected List<Bullet> _bulletsPool = new List<Bullet>();

    public Sprite Icon { get => _icon; set => _icon = value; }

    public static event Action OnShoot;
    public static event Action OnRecharge;
    private Coroutine _rechargeCoroutine;
    protected bool _isShoot;
    protected float _elapsedTime;

    private void Start()
    {
        for (int i = 0; i < _maxAmoutOfBullets + 20; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bulletsPool.Add(bullet);
        }
    }

    public Bullet GetBullet()
    {
        for (int i = 0; i < _bulletsPool.Count; i++)
        {
            if (!_bulletsPool[i].gameObject.activeSelf)
            {
                _bulletsPool[i].gameObject.SetActive(true);
                _bulletsPool[i].gameObject.transform.position = _shootPoint.transform.position;
                return _bulletsPool[i];
            }
        }
        return null;
    }

    public abstract void Shoot(Vector3 direction);

    public abstract void CheckShootButtonPress(Vector3 direction);

    public void ShootAction()
    {
        OnShoot?.Invoke();
    }

    public void Recharge()
    {
        if (_rechargeCoroutine == null)
        {
            _rechargeCoroutine = StartCoroutine(RechargeCoroutine());
        }
    }

    private IEnumerator RechargeCoroutine()
    {
        _rechargeImage.fillAmount = 0;
        while (_rechargeImage.fillAmount < 1)
        {
            yield return new WaitForSeconds(0.02f);
            _rechargeImage.fillAmount += _rechargeSpeed / 100;
        }
        _amountOfbullets = _maxAmoutOfBullets;
        OnShoot?.Invoke();
        _rechargeCoroutine = null;
    }
}
