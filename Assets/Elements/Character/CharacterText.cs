using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterText : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private int characterCount = 1;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        CharactersManager.OnCharacterSpawned += AddCharacter;
        CharactersManager.OnCharacterRemoved += RemoveCharacter;
    }

    public void AddCharacter()
    {
        characterCount++;
        textMesh.text = characterCount.ToString();
    }
    
    public void RemoveCharacter()
    {
        characterCount--;
        textMesh.text = characterCount.ToString();
    }

    private void OnDestroy()
    {
        CharactersManager.OnCharacterSpawned -= AddCharacter;
        CharactersManager.OnCharacterRemoved -= RemoveCharacter;
    }
}
