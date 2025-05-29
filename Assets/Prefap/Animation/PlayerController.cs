// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public float jumpForce = 8f;

//     private Rigidbody2D rb;
//     private Animator animator;
//     private bool isGrounded = true;
//     private bool isDead = false;

//     private Vector3 originalScale;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         animator = GetComponent<Animator>();
//         originalScale = transform.localScale;
//     }

//     void Update()
//     {
//         if (isDead) return;

//         float move = Input.GetAxisRaw("Horizontal");

//         // الحركة يمين ويسار
//         rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

//         // تغيير الاتجاه حسب الجهة
//         if (move > 0)
//             transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
//         else if (move < 0)
//             transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);

//         // تحديث حالة المشي
//         animator.SetBool("isWalking", move != 0);

//         // القفز عند الضغط على Space
//         if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//         {
//             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//             animator.SetTrigger("Jump");
//             isGrounded = false;
//         }
//     }

//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         // التأكد أنه على الأرض
//         if (collision.collider.CompareTag("Ground"))
//         {
//             isGrounded = true;
//         }
//     }

//     void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("DeadZone"))
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         if (isDead) return;

//         isDead = true;
//         animator.SetTrigger("Dead");
//         rb.velocity = Vector2.zero;
//         rb.bodyType = RigidbodyType2D.Static; // إيقاف الحركة بعد الموت
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement; // لاستدعاء المشاهد

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = true;
    private bool isDead = false;

    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (isDead) return;

        float move = Input.GetAxisRaw("Horizontal");

        // الحركة يمين ويسار
        rb.linearVelocity= new Vector2(move * moveSpeed,rb.linearVelocity.y);

        // تغيير الاتجاه حسب الجهة
        if (move > 0)
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        else if (move < 0)
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);

        // تحديث حالة المشي
        animator.SetBool("isWalking", move != 0);

        // القفز عند الضغط على Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
           rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("Dead");
       rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;

        // إعادة تحميل المشهد بعد ثانيتين
        Invoke("ReloadScene", 2f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Start"); // غيّر الاسم إذا كان مشهدك يحمل اسم مختلف
    }
}
