using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject spikeVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            GameObject spikeVFXInstance = Instantiate(spikeVFX, transform.position, Quaternion.identity);
            Destroy(spikeVFXInstance, 1f);
            Destroy(gameObject);
        }
    }
    
}
