using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private float jumpForce, moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MoveRight();
    }

    void Update(){
        MoveRight();
    }


    public void Fly(){
        rb.velocity = Vector3.up * jumpForce;
    }
    // Move to the right 
    public void MoveRight(){
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
