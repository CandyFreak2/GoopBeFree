using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopMovement : MonoBehaviour
{
    private float horizontalMovement;
    private bool isFacingRight = true;

    [SerializeField] private float playerSpeed = 3.5f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        Flip();
    }

    private void FixedUpdate() {
        rigidBody.velocity = new Vector2(horizontalMovement * playerSpeed, rigidBody.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() {
        if (isFacingRight && horizontalMovement < 0f || !isFacingRight && horizontalMovement > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
