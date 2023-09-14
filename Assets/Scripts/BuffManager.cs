using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuffManager : MonoBehaviour
{

    public GameObject playerFab;
    public bool isFirst;
    
    
    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Gate") {
            if (other.GetComponent<Gate>().isPositive) {

                if (isFirst)
                {
                    GameObject playerCopy = Instantiate(playerFab, transform.position, Quaternion.identity);
                    playerCopy.GetComponent<BuffManager>().isFirst = false;
                }
                
            } else {
                transform.localScale *= 0.8f;

                Debug.Log("Add a debuff");
            }
        }
    }

    private void SummonCopies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject playerCopy = Instantiate(playerFab, transform.position, Quaternion.identity);
            playerCopy.GetComponent<BuffManager>().isFirst = false;
        }
    }
}
