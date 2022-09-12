using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkinUI : MonoBehaviour
{
    public SkinSO skinData;

    public Image skinImage;
    public GameObject buyButton, equipButton;
    public TextMeshProUGUI priceText;

    public static Action<int> OnEquip;

    private void Start()
    {
        LoadData();
        EquipSkin(PlayerData.Instance.equipedSkin.skinId);
        OnEquip += EquipSkin;
    }

    public void OnClick_Buy()
    {
        if (ShopManager.TryBuy(skinData.price))
        {
            skinData.buyed = true;
            LoadData();
        }
    }

    public void OnClick_Equip()
    {
        PlayerData.Instance.SetEquipedSkin(skinData);
        OnEquip?.Invoke(skinData.skinId);
    }

    public void EquipSkin(int id)
    {
        if (id == skinData.skinId)
        {
            equipButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            equipButton.GetComponent<Button>().interactable = true;
        }
    }

    public void LoadData()
    {
        if (skinData.buyed)
        {
            equipButton.SetActive(true);
            buyButton.SetActive(false);
        }
        skinImage.color = skinData.skinMaterial.color;

        if (skinData.price > 0)
        {
            priceText.text = "" + skinData.price;
        }
        else
        {
            priceText.text = "Free";
        }

    }

    private void OnDestroy()
    {
        OnEquip -= EquipSkin;
    }
}
