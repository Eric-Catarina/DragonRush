using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BuffManager : MonoBehaviour
{

    public GameObject playerFab;
    private CharactersManager charactersManager;
    public bool isFirst;
    
    void Start()
    {
        charactersManager = GameObject.Find("CharactersManager").GetComponent<CharactersManager>();
    }
    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Gate") {
            if (other.GetComponent<Gate>().isPositive) {

                if (isFirst)
                {
                    charactersManager.SummonCharacter();
                }
                
            } else {
                transform.localScale *= 0.8f;

                Debug.Log("Add a debuff");
            }
        }
        
       
    }



}
