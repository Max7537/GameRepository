using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCard : MonoBehaviour
{
    [SerializeField] private Image _icon;
    private WeaponType _weaponType;

    public void SetImage(Sprite icon, WeaponType weaponType)
    {
        _icon.sprite = icon;
        _weaponType = weaponType;
    }

    public void SelectWeapon()
    {
        PlayerAttack _player = FindObjectOfType<PlayerAttack>();
        _player.SetWeapon(_weaponType);
    }
}
