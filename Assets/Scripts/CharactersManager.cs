using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public GameObject playerFab, jumpSpotFab, firstCharacter, lastCharacter;
    public Vector3 initialSpawnPosition;
    public List<GameObject> charactersList = new List<GameObject>();
    public float distanceBetweenCharacters = 1.2f;

    void Start(){
        if(!firstCharacter) SummonCharacter();
        charactersList.Add(firstCharacter);

    }
    public void RemoveCharacter(GameObject character){
        charactersList.Remove(character);
        Destroy(character);
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
        Vector3 position = lastCharacter.transform.position;
        position.x += Random.Range(0.8f, distanceBetweenCharacters);
        GameObject characterInstance = Instantiate(playerFab, position, Quaternion.identity);
        characterInstance.GetComponent<BuffManager>().isFirst = false;

        SetColor(GetRandomColor(), characterInstance);
        
        charactersList.Add(characterInstance);
        lastCharacter = charactersList[charactersList.Count - 1];
        return characterInstance;
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
        GameObject jumpSpotInstance = Instantiate(jumpSpotFab, firstCharacter.transform.position, Quaternion.identity);
        return jumpSpotInstance;
    }


}
