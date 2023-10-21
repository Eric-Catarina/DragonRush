using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharactersManager charactersManager;
    
    void Start()
    {
        charactersManager = GameObject.Find("CharactersManager").GetComponent<CharactersManager>();
    }

    public void Die()
    {
        charactersManager.RemoveCharacter(gameObject);
    }

}
