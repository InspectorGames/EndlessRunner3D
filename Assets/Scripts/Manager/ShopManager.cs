using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public List<SkinSO> skins;
    public GameObject skinShopContent;
    public GameObject skinUIPf;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        foreach(SkinSO sk in skins)
        {
            Instantiate(skinUIPf, skinShopContent.transform, worldPositionStays: false).GetComponent<SkinUI>().skinData = sk;
        }
        gameObject.SetActive(false);
    }

    public static bool TryBuy(int coinsPrice)
    {
        if((PlayerData.Instance.coins - coinsPrice) >= 0)
        {
            BuyedSomething(coinsPrice);
            return true;
        }
        return false;
    }

    public static void BuyedSomething(int coinsPrice)
    {
        PlayerData.Instance.RemoveCoins(coinsPrice);
    }
}
