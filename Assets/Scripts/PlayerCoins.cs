using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField] private float _coins;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private PlayerAttack _playerAttack;

    [SerializeField] private Weapon _weapon;

    private void Start()
    {
        _coinsText.text = _coins.ToString();
    }

    public void GetReward(float reward)
    {
        _coins += reward;
        _coinsText.text = _coins.ToString();
    }

    public void TryBuyButtonPress()
    {
        TryBuy(_weapon);
    }

    public bool TryBuy(Weapon weapon)
    {
        if (weapon.Price <= _coins)
        {
            _coins -= weapon.Price;
            _coinsText.text = _coins.ToString();
            _playerAttack.AddNewWeapon(weapon);
            return true;
        }
        return false;
    }
}
