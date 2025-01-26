using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInterface : MonoBehaviour
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private TMP_Text _bulletText;
    [SerializeField] private Slider _bulletSlider;
    [SerializeField] private Image _bulletImage;
    [SerializeField] private Image _bulletImageRed;
    [SerializeField] private Transform _bulletImageContainer;
    [SerializeField] private Image _bulletPrefab;
    [SerializeField] private Bomb _bomb;
    [SerializeField] private float _bombsAmount;

    private List<Image> _bulletImages = new List<Image>();
    
    private void OnEnable()
    {
        Weapon.OnShoot += OnChangeShootValues;
        _playerAttack.ChangeWeapon += SetWeapon;
    }

    private void OnDisable()
    {
        Weapon.OnShoot -= OnChangeShootValues;
        _playerAttack.ChangeWeapon -= SetWeapon;
    }

    private void OnChangeShootValues()
    {
        _bulletText.text = _playerAttack._currentWeapon.AmountOfAllBullets.ToString();
        if (_bulletImages.Count > 0)
        {
            for (int i = 0; i < _bulletImages.Count; i++)
            {
                Destroy(_bulletImages[i].gameObject);
            }
            _bulletImages.Clear();
        }

        for (int i = 0; i < _playerAttack._currentWeapon.AmountOfBullets; i++)
        {
            _bulletImages.Add(Instantiate(_bulletPrefab, _bulletImageContainer));
        }
    }

    private void OnChangeMaxValues()
    {
        _bulletText.text = _playerAttack._currentWeapon.AmountOfAllBullets.ToString();
        _bulletSlider.maxValue = _playerAttack._currentWeapon._maxAmoutOfBullets;
    }

    public void SetWeapon()
    {
        OnChangeMaxValues();
        OnChangeShootValues();
        _bulletImage.sprite = _playerAttack._currentWeapon.Icon;
        _bulletImageRed.sprite = _playerAttack._currentWeapon.Icon;
    }

    public void Bombardment()
    {
        StartCoroutine(BombardmentCoroutine());
    }

    public IEnumerator BombardmentCoroutine()
    {
        float bombsSpawned = 0;
        while (bombsSpawned < _bombsAmount)
        {
            yield return new WaitForSeconds(0.2f);
            Bomb bomb = Instantiate(_bomb);
            bomb.gameObject.transform.position = new Vector3(Random.Range(-4.5f, 10), 7, 0);
            bomb.gameObject.transform.Rotate(0, 0, Random.Range(0, 360));
            bombsSpawned++;
        }
    }
}
