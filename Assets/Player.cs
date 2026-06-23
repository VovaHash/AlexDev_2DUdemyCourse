using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private float xInput;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private float moveSpeed = 7f;
    private float jumpForce = 6f;
    private bool isMoving;
    //[Header("Movement")]
    [SerializeField] private bool facingRight = true;

    //[Header("Collision")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayerMask;





    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleCollision();
        HandleInput();
        HandleMovement();
        HandleFlip();
        HandleAnimations();
    }

    


    private void HandleAnimations()
    {
        
        isMoving = rigidBody.linearVelocity.x != 0;
        animator.SetBool("isMoving", isMoving);


    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void HandleMovement()
    {
        rigidBody.linearVelocity = new Vector2(xInput * moveSpeed, rigidBody.linearVelocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
        }
        
    }

    private void HandleFlip()
    {
        if (rigidBody.linearVelocity.x > 0 && facingRight == false)
            Flip();
        else if (rigidBody.linearVelocity.x < 0 && facingRight == true)
            Flip();
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
       
    }

    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0,-groundCheckDistance));
    }

}
