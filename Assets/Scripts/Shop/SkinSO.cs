using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Skin", menuName = "Endless Runner/Skin")]
public class SkinSO : ScriptableObject
{
    public int skinId;
    public string skinName;
    public int price;
    public bool buyed = false;

    public Material skinMaterial; //For testing

    //TODO: Automatically assign the id
}