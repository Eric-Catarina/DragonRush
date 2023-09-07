using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private GameObject playerFab;
    public bool isPositive;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Positive");

        if (collision.gameObject.tag == "Player")
        {
            if (isPositive)
            {
                Instantiate(playerFab, transform.position, Quaternion.identity);
            }
            else
            {
                //Destroy(collision.gameObject);
            }
        }
    }

}
