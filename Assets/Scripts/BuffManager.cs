using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Gate") {
            if (other.GetComponent<Gate>().isPositive) {
                Debug.Log("Add a buff");
                // Increase self scale by 1.2x
                transform.localScale *= 1.2f;

            } else {
                transform.localScale *= 0.8f;

                Debug.Log("Add a debuff");
            }
        }
    }
}
