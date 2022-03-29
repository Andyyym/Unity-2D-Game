using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Vector2 LastMotionVector;
    bool isFacingRight = true;

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if(moveX != 0 || moveY != 0)
        {
            LastMotionVector = new Vector2(moveY, moveX).normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
        Direction();
    }

   
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Direction()
    {
        if (moveDirection.x > 0 && isFacingRight == false)
        {
            Flip();
        }
        else if (moveDirection.x < 0 && isFacingRight == true)
        {
            Flip();
        }
    }
}
