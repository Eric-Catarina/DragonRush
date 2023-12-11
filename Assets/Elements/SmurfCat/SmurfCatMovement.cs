using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmurfCatMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float horizontalSpeed = 2.0f; // Adjust this value to control the smoothness of horizontal movement.


    private Rigidbody rb;
    private Vector3 targetVelocity;

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


    private void FixedUpdate()
    {
        targetVelocity.x = -moveSpeed;
        rb.MovePosition(transform.position + targetVelocity * Time.fixedDeltaTime);
        targetVelocity = Vector3.zero;
        
    }

    public void MoveHorizontally(InputAction.CallbackContext value)
    {
        if (value.phase == InputActionPhase.Performed)
        {
            Vector2 moveInput = value.ReadValue<Vector2>();
            float moveInputX = moveInput.x;

            // Calculate the target velocity based on the input.
            targetVelocity = new Vector3(0, 0, moveInputX * moveSpeed);

            // Interpolate the character's velocity smoothly toward the target velocity.
            targetVelocity = Vector3.Lerp(rb.velocity, targetVelocity, horizontalSpeed * Time.fixedDeltaTime);
        }
        else if (value.phase == InputActionPhase.Canceled)
        {
            // If input is released, set velocity to zero to stop movement.
            rb.velocity = Vector3.zero;
        }
    }
    


}