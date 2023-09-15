using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public GameObject playerFab, firstCharacter;
    public Vector3 initialSpawnPosition;
    public List<GameObject> charactersList = new List<GameObject>();

    void Start(){
        if(!firstCharacter) SummonCharacter(initialSpawnPosition);
        
    }

    public GameObject SummonCharacter(Vector3 position){

        GameObject characterInstance = Instantiate(playerFab, position, Quaternion.identity);
        charactersList.Add(characterInstance);
        return characterInstance;
    }

}
