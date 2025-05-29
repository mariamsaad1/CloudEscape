using UnityEngine;
using SolarSoft.PlatformerFree.Player;

/// <summary>
/// Deals damage to the player on contact.
/// Can be used for enemies, spikes, traps, etc.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    public class TouchDamage : MonoBehaviour
    {
        public float damageAmount = 1f;

        // private void OnTriggerEnter2D(Collider2D collision)
        // {
        //     if (collision.CompareTag("Player"))
        //     {
        //         Debug.Log("estadam ");
        //         var health = collision.GetComponent<PlayerHealth>();
        //         if (health != null)
        //         {
        //             health.TakeDamage(damageAmount);
        //             Debug.Log("naqas ");

        //         }
        //     }
        // }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("estadam ");
                var health = collision.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage(damageAmount);
                    Debug.Log("naqas ");

                    // ✅ تفعيل التريجر "lightning" في الأنيميتر
                    Animator animator = collision.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetTrigger("lightning");
                    }
                }
            }
        }
    }
}