using UnityEngine;

public class Player : MonoBehaviour
{

    private float xInput;
    private Rigidbody2D rigidBody;
    private float moveSpeed = 3.5f;
    private float jumpForce = 5f;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();

        


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

   

}
