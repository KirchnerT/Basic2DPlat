using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int jumpsAmount;
    int jumpsLeft;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    bool isGrounded;

    public float moveInput;
    Rigidbody2D rb2d;
    float scaleX;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Jump();

    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Flip();
        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
    }

    /// <summary>
    /// Flips the character sprite
    /// </summary>
    public void Flip()
    {
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (moveInput < 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    /// <summary>
    /// Checks if the player is trying to jump and if they can jump
    /// </summary>
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfGrounded();

            if (jumpsLeft > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpsLeft--;
            }

        }

    }

    /// <summary>
    /// Checks if the player is on the ground
    /// If they are, reset jumps
    /// </summary>
    public void CheckIfGrounded()
    {
        //isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);

        isGrounded = Physics2D.OverlapBox(GroundCheck.position, GroundCheck.GetComponent<BoxCollider2D>().size, 0, GroundLayer);
        ResetJumps();
    }

    /// <summary>
    /// Resets the jumps to the maximum jumps
    /// </summary>
    public void ResetJumps()
    {
        if (isGrounded)
        {
            jumpsLeft = jumpsAmount;// jumpsAmount =2;
        }
    }


}
