// using UnityEngine;

// public class PlayerControllerPH : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarSoft.PlatformerFree
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerControllerPH : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        public float jumpForce = 12f;
        public float coyoteTime = 0.15f;
        public float jumpCutMultiplier = 0.5f;

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

        // لمس
        private float lastTapTime = 0f;
        private float doubleTapThreshold = 0.3f;
        private bool isTouchHeld = false;
        private float touchHoldDirection = 0f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            HandleInput();
            HandleJump();

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
            // كيبورد
            moveInput = Input.GetAxisRaw("Horizontal");

            // لمس
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = touch.position;
                float screenMid = Screen.width / 2f;

                // دبل تاب
                if (touch.phase == TouchPhase.Began)
                {
                    float timeSinceLastTap = Time.time - lastTapTime;

                    if (timeSinceLastTap <= doubleTapThreshold && coyoteTimeCounter > 0f)
                    {
                        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                    }

                    lastTapTime = Time.time;

                    // لف يسار أو يمين فقط
                    if (touchPos.x < screenMid)
                    {
                        if (isFacingRight) Flip();
                    }
                    else
                    {
                        if (!isFacingRight) Flip();
                    }

                    // بداية الضغط
                    isTouchHeld = true;
                    touchHoldDirection = (touchPos.x < screenMid) ? -1f : 1f;
                }

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isTouchHeld = false;
                    touchHoldDirection = 0f;

                    // قص الجُمب لو رفع إصبعه بسرعة
                    if (rb.linearVelocity.y > 0)
                    {
                        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * jumpCutMultiplier);
                    }
                }

                // أثناء الضغط
                if (isTouchHeld)
                {
                    moveInput = touchHoldDirection;
                }
            }

            // وجه الشخصية حسب الاتجاه
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
