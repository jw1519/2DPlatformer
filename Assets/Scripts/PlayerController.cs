using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int movementSpeed;
    public int jumpHeight;

    float horizontalMovement;
    float verticalMovement;

    PlayerInput playerInput;

    //actions
    InputAction jumpAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["Jump"];
    }
    private void Update()
    {
        rb.velocity = new Vector2 (horizontalMovement * movementSpeed, verticalMovement * jumpHeight);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        verticalMovement = context.ReadValue<Vector2>().y;
    }
    private void Attack()
    {
        Debug.Log("Attack");
    }
    
}
