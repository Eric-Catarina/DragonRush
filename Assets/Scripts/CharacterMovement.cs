using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
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
        // if is grounded, set color to green
        if (isGrounded && isFirst)
        {
            charactersManager.SetColor(Color.green, gameObject);
        }
        else if (!isGrounded && isFirst)
        {
            charactersManager.SetColor(Color.red, gameObject);
        }
    }

    public void Jump(){
        GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
        
    }

    public void JumpSpot()
    {

        if (isFirst && isGrounded)
        {
            isGrounded = false;
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
            charactersManager.SetJumpSpot();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpSpot")
        {
            Jump();
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            // Wait 0.1 seconds before setting isGrounded to false
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


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        
    }
    
    private void SetIsGroundedFalse()
    {
        isGrounded = false;
    }

}
