using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SmurfCatMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    private Rigidbody rb; // Assuming you're using a Rigidbody for physics-based movement.

    private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.actions.Enable();
    }

    private void OnDisable()
    {
        playerInput.actions.Disable();
    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    
    private void OnMoveLeft(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        Vector3 moveDirection = new Vector3(0, 0, -moveInput.x); // Use x-axis from Vector2
        rb.velocity = moveDirection * moveSpeed;
    }

    private void OnMoveRight(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        Vector3 moveDirection = new Vector3(0, 0, moveInput.x); // Use x-axis from Vector2
        rb.velocity = moveDirection * moveSpeed;
    }
}