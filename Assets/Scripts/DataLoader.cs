using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public MeshRenderer playerMesh;

    private void Start()
    {
        playerMesh.material = PlayerData.Instance.equipedSkin.skinMaterial;
    }
}
