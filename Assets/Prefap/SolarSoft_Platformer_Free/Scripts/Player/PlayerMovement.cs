
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles 2D player movement, jumping, and ground detection.
/// Designed to be modular and easily extensible.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        public float jumpForce = 12f;
        public float coyoteTime = 0.15f; // Buffer after falling to still allow jumping
        public float jumpCutMultiplier = 0.5f; // Reduces jump height when jump is released early

        [Header("Ground Detection")]
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;
        public LayerMask groundLayer;

        private Rigidbody2D rb;
        private float moveInput;
        private bool isGrounded;
        private float coyoteTimeCounter;
        private bool isFacingRight = true;

        private Animator animator;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            HandleInput();
            HandleJump();

            // Update animation parameters
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("IsJumping", !isGrounded);
        }

        private void FixedUpdate()
        {
            CheckGrounded();
            ApplyMovement();
        }

        private void HandleInput()
        {
            moveInput = Input.GetAxisRaw("Horizontal");

            if ((moveInput > 0 && !isFacingRight) || (moveInput < 0 && isFacingRight))
            {
                Flip();
            }
        }

        private void ApplyMovement()
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }

        private void HandleJump()
        {
            if (isGrounded)
                coyoteTimeCounter = coyoteTime;
            else
                coyoteTimeCounter -= Time.deltaTime;

            if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }

            if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * jumpCutMultiplier);
            }
        }

        private void CheckGrounded()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }
    public IEnumerator TempSpeedBoost(float boostAmount, float duration)
    {
        moveSpeed += boostAmount;
        yield return new WaitForSeconds(duration);
        moveSpeed -= boostAmount;
    }

    }



    
}