using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        PlayerData.OnCoinsValueChanged += UpdateCoinsText;
        coinsText.text = "Coins: " + PlayerData.Instance.coins;
    }

    private void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + PlayerData.Instance.coins;
    }

    public void OnClick_MainMenu()
    {
        MenuManager.OpenMenu(Menu.MainMenu, this.gameObject);
    }
}
