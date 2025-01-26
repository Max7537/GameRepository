using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShop : MonoBehaviour
{
    [SerializeField] private PlayerCoins playerCoins;
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();
    [SerializeField] private BuyButton _button;
    [SerializeField] private List<BuyButton> _buttons = new List<BuyButton>();
    [SerializeField] private GameObject _container;

    void Start()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            BuyButton button = Instantiate(_button, _container.transform);
            _buttons.Add(button);
            button.Click += Buy;
            button.Initialize(weapons[i]);
        }
    }

    private void Buy(BuyButton buyButton)
    {
        Debug.Log(1);
        if (playerCoins.TryBuy(buyButton._weapon))
        {
            Debug.Log(2);
            _buttons.Remove(buyButton);
            Destroy(buyButton.gameObject);
        }
    }

    public void CloseShop()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
