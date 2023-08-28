using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float jumpForce = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    public void Jump(){
        GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
    }

    void OnTriggerEnter(Collider other){
            //Destroy(other.gameObject);
        
    }


}
