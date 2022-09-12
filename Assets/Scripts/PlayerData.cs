using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }
    public SkinSO equipedSkin { get; private set; }
    public int coins { get; private set; }

    public static Action OnCoinsValueChanged;

    public SkinSO defaultSkin;


    private void Start()
    {
        equipedSkin = defaultSkin;
        SaveData data = SaveSystem.LoadData();
        if(data != null)
        {
            foreach(SkinSO skin in ShopManager.instance.skins)
            {
                if(skin.skinId == data.skinId)
                {
                    equipedSkin = skin;
                    break;
                }
            }
            coins = data.coins;
        }
    }

    public void SetEquipedSkin(SkinSO skin)
    {
        equipedSkin = skin;
    }

    public void SetCoins(int newCoins)
    {
        coins = newCoins;
        if(coins != newCoins)
        {
            OnCoinsValueChanged?.Invoke();
        }
    }

    public void AddCoins(int newCoins)
    {
        coins += newCoins;
        OnCoinsValueChanged?.Invoke();
    }

    public void RemoveCoins(int coinsRemoved)
    {
        if(coins > 0)
        {
            coins -= coinsRemoved;
            OnCoinsValueChanged?.Invoke();
        }
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SaveData();
    }
}
