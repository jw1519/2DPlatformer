using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    GroundSensor groundSensor;
    public int movementSpeed;
    public int jumpPower;

    float horizontalMovement;

    [Header("GroundCheck")]
    public Transform GroundCheckPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundSensor = GroundCheckPos.GetComponent<GroundSensor>();
    }
    private void Update()
    {
        rb.linearVelocity = new Vector2 (horizontalMovement * movementSpeed, rb.linearVelocity.y);
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("Attack");
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        if (horizontalMovement != 0)
        {
            animator.SetBool("Running", true);
        }
        else
            animator.SetBool("Running", false);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (groundSensor.IsGrounded() == true)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
            animator.SetBool("Grounded", false);
        }
    }
    public void Crouch(InputAction.CallbackContext context)
    {
        if (groundSensor.IsGrounded() == true)
        {
            Debug.Log("Crouch");
            if (context.performed)
            {
                animator.SetBool("Crouching", true);
            }
            else if (context.canceled)
            {
                animator.SetBool("Crouching", false);
            }
        }
    }
    public void Die()
    {
        animator.SetTrigger("Death");
    }
}
