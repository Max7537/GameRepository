using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelecter : MonoBehaviour
{
    [SerializeField] private GameObject WeaponContainer;
    [SerializeField] private PlayerAttack _player;
    [SerializeField] private WeaponCard _weaponCard;

    private void OnEnable()
    {
        _player.AddedNewWeapon += AddNewWeapon;
    }

    private void OnDisable()
    {
        _player.AddedNewWeapon -= AddNewWeapon;
    }

    private void Start()
    {
        for (int i = 0; i < _player.Weapons.Count; i++)
        {
            AddNewWeapon(_player.Weapons[i]);
        }
    }

    private void AddNewWeapon(Weapon weapon)
    {
        WeaponCard weaponCard = Instantiate(_weaponCard, WeaponContainer.transform);
        weaponCard.SetImage(weapon.Icon, weapon._weaponType);
    }
}
