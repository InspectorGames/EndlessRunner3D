using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Remover"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            GameManager.CoinCollected();
            Destroy(gameObject);
        }
    }
}
