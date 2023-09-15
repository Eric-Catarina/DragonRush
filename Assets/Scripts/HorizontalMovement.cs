using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public BuffManager buffManager;
    public CharactersManager charactersManager;
    public float moveSpeed = 5;
    public float jumpForce = 5;
    public bool isFirst, isGrounded;


    void Start()
    {
        charactersManager = GameObject.Find("CharactersManager").GetComponent<CharactersManager>();
        buffManager = GetComponent<BuffManager>();
        isFirst = buffManager.isFirst;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    public void Jump(){
        if (isFirst && isGrounded)
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
            charactersManager.SetJumpSpot();
        }
        
    }

    public void JumpSpot()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpSpot")
        {
            JumpSpot();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Tocou o chao");
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
