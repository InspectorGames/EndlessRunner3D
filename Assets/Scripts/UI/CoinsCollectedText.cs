using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCollectedText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Start()
    {
        GameManager.OnCoinCollected += UpdateCoinText;
    }

    private void UpdateCoinText()
    {
        text.text = "Coins Collected: " + GameManager.coinsCollected;
    }
}
