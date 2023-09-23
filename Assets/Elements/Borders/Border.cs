using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        { 
            other.gameObject.GetComponent<Character>().Die();   
        }
    }
}
