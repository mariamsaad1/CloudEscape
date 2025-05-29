// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.Collections;
// using SolarSoft.PlatformerFree.Checkpoints;

// namespace SolarSoft.PlatformerFree.Player
// {
//     /// <summary>
//     /// Handles player health, death animation, and respawn logic.
//     /// </summary>
//     [RequireComponent(typeof(Animator))]
//     public class PlayerHealth : MonoBehaviour
//     {
//         [Header("Health Settings")]
//         public float maxHealth = 3f;
//         public float threshold = -10f;
//         private float currentHealth;
//         private bool isDead = false;
//         public AudioSource sound;

//         public HealthBarUI healthBar;

//         [Header("Respawn Settings")]
//         [SerializeField] private Transform startPosition;

//         private Animator animator;

//         private void Start()
//         {
//             animator = GetComponent<Animator>();
//             currentHealth = maxHealth;
//             healthBar.UpdateHealth(currentHealth, maxHealth);
//         }

//         private void Update()
//         {
//             if (transform.position.y < threshold)
//             {
//                 Die();
//             }
//         }

//         /// <summary>
//         /// Call this to damage the player.
//         /// </summary>
//         public void TakeDamage(float amount)
//         {
//             if (isDead) return;

//             currentHealth -= amount;
//             healthBar.UpdateHealth(currentHealth, maxHealth);

//             if (currentHealth <= 0)
//             {
//                 Die();
//             }
//         }
//         public void TakeLife(float amount)
//         {

//             currentHealth += amount;
//             if (currentHealth > maxHealth)
//             {
//                 healthBar.UpdateHealth(currentHealth, maxHealth);
//             }



//         }

//         private void Die()
//         {
//             if (isDead) return;

//             isDead = true;

//             animator.SetTrigger("Die");
//             sound.Play();

//             var movement = GetComponent<PlayerMovement>();
//             if (movement != null)
//                 movement.enabled = false;

//             StartCoroutine(HandleDeath());
//         }

//         /// <summary>
//         /// Handles the death animation and delayed respawn.
//         /// </summary>
//         private IEnumerator HandleDeath()
//         {
//             yield return new WaitForSeconds(1f);

//             Vector3 respawnPos = CheckpointManager.HasCheckpoint()
//                 ? CheckpointManager.GetCheckpoint()
//                 : startPosition.position;

//             transform.position = respawnPos;
//             GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

//             currentHealth = maxHealth;
//             healthBar.UpdateHealth(currentHealth, maxHealth);

//             var movement = GetComponent<PlayerMovement>();
//             if (movement != null)
//                 movement.enabled = true;

//             isDead = false;
//         }
//     }
// }




using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using SolarSoft.PlatformerFree.Checkpoints;

namespace SolarSoft.PlatformerFree.Player
{
    /// <summary>
    /// Handles player health, death animation, and respawn logic.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Health Settings")]
        public float maxHealth = 3f;
        public float threshold = -10f;
        private static float currentHealth;
        private bool isDead = false;
        public AudioSource sound;
        public HealthEffects show;

        // استبدال شريط الصحة بنص يظهر الصحة
        // public HealthBarUI healthBar; // تم التعليق لتعطيل الشريط
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI WinHealthText;


        [Header("Respawn Settings")]
        [SerializeField] private Transform startPosition;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
            show = GetComponent<HealthEffects>();
            currentHealth = maxHealth;
            UpdateHealthText();
        }

        private void Update()
        {
            if (transform.position.y < threshold)
            {
                Die();
            }
        }

        /// <summary>
        /// Call this to damage the player.
        /// </summary>
        public void TakeDamage(float amount)
        {
            if (isDead) return;

            currentHealth -= amount;
            UpdateHealthText();
            show.ShowDamageText(amount);
            Debug.Log($"Showed");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void TakeLife(float amount)
        {
            currentHealth += amount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            UpdateHealthText();
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;

            animator.SetTrigger("Die");
            sound.Play();

            var movement = GetComponent<PlayerMovement>();
            if (movement != null)
                movement.enabled = false;

            StartCoroutine(HandleDeath());
        }

        /// <summary>
        /// Handles the death animation and delayed respawn.
        /// </summary>
        private IEnumerator HandleDeath()
        {
            yield return new WaitForSeconds(1f);

            Vector3 respawnPos = CheckpointManager.HasCheckpoint()
                ? CheckpointManager.GetCheckpoint()
                : startPosition.position;

            transform.position = respawnPos;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

            currentHealth = maxHealth;
            UpdateHealthText();

            var movement = GetComponent<PlayerMovement>();
            if (movement != null)
                movement.enabled = true;

            isDead = false;
        }

        /// <summary>
        /// Updates the health text UI
        /// </summary>
        private void UpdateHealthText()
        {
            if (healthText != null)
            {
                healthText.text = $"{currentHealth}";
                WinHealthText.text = $"{currentHealth}";
            }
        }

        public void ResetPlayer()
        {
            CheckpointManager.ResetCheckpoint();

            Vector3 respawnPos = startPosition.position;

            transform.position = respawnPos;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

            currentHealth = maxHealth;
            UpdateHealthText();

            var movement = GetComponent<PlayerMovement>();
            if (movement != null)
                movement.enabled = true;

            isDead = false;
        }
    }
}
