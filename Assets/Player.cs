using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float xInput;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private float moveSpeed = 7f;
    private float jumpForce = 6f;
    [SerializeField] private bool facingRight = true;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleFlip();
        HandleAnimations();
    }

    public bool isMoving;


    private void HandleAnimations()
    {

        bool isMoving = rigidBody.linearVelocity.x != 0;
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
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
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

}
