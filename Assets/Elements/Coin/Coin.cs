using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnCoinCollected;
    public GameObject coinVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            OnCoinCollected?.Invoke();
            Instantiate(coinVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
    // Keeps rotating in Y
    private void FixedUpdate()
    {
        transform.Rotate(0, 1, 0);
    }
    
    
}