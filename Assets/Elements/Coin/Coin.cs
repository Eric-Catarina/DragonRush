using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnCoinCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            OnCoinCollected?.Invoke();
            
            Destroy(gameObject);
        }
    }
    
    
    
    


}