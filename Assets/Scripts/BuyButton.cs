using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private Image _icon;

    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _nameText;
    
    [SerializeField] public Weapon _weapon;

    public Action<BuyButton> Click;

    public void OnCLick()
    {
        Click?.Invoke(this);
    }

    public void Initialize(Weapon weapon)
    {
        _weapon = weapon;
        _icon.sprite = _weapon.Icon;
        _priceText.text = _weapon.Price.ToString();
        _nameText.text = _weapon.Name;
    }
}
