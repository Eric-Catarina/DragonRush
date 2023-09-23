using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnCoinCollected;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin's OnTriggerEnter method called.");
        if (other.gameObject.tag == "Character")
        {
            OnCoinCollected?.Invoke();
            
            Destroy(gameObject);
        }
    }
    
    
    
    


}