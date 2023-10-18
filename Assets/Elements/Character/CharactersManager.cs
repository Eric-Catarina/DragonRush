using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharactersManager : MonoBehaviour
{
    public GameObject playerFab, jumpSpotFab, firstCharacter, lastCharacter;
    public Vector3 initialSpawnPosition;
    public List<GameObject> charactersList = new List<GameObject>();
    public float distanceBetweenCharacters = 1.2f;
    public static event Action OnCharacterSpawned, OnCharacterRemoved;
    private AudioManager audioManager;

    void Start(){
        if(!firstCharacter) SummonCharacter();
        charactersList.Add(firstCharacter);
        Time.timeScale = 1;
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();

    }
    
    public int GetIndex(GameObject character)
    {
        return charactersList.IndexOf(character);
    }
    public GameObject GetCharacter(int index)
    {
        return charactersList[index];
    }


    public GameObject SummonCharacter(){

        audioManager.PlaySFX(audioManager.musicClips[0]);

        Vector3 position = lastCharacter.transform.position;
        position.x += Random.Range(0.8f, distanceBetweenCharacters);
        GameObject characterInstance = Instantiate(playerFab, position, Quaternion.identity);
        characterInstance.GetComponent<BuffManager>().isFirst = false;

        SetColor(GetRandomColor(), characterInstance);
        
        charactersList.Add(characterInstance);
        characterInstance.GetComponent<Rigidbody>().velocity = lastCharacter.GetComponent<Rigidbody>().velocity;
        lastCharacter = charactersList[charactersList.Count - 1];
        OnCharacterSpawned?.Invoke();
        return characterInstance;
    }
    public void RemoveCharacter(GameObject character){
        charactersList.Remove(character);
        OnCharacterRemoved?.Invoke();
        Destroy(character);
        if(charactersList.Count == 0){
            Debug.Log("Game Over");
            
        }
    }
    
    public void SetColor(Color color, GameObject character)
    {
        Material material = character.GetComponentInChildren<Renderer>().material;
        material.color = color;
    }
    
    public Color GetRandomColor()
    {
        return Color.HSVToRGB(Random.Range(0f, 1f), 1, 1);
    }
    
    public int GetCharactersCount()
    {
        return charactersList.Count;
    }

    public GameObject SetJumpSpot()
    {
        Vector3 position = firstCharacter.transform.position;
        position.y -= 0.5f;
        GameObject jumpSpotInstance = Instantiate(jumpSpotFab, position, Quaternion.identity);
        return jumpSpotInstance;
    }


}
