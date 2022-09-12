using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData
{
    public int skinId;
    public int coins;

    public SaveData()
    {
        skinId = PlayerData.Instance.equipedSkin.skinId;
        coins = PlayerData.Instance.coins;
    }
}
