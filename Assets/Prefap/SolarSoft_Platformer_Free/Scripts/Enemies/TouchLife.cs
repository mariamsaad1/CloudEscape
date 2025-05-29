using UnityEngine;
using SolarSoft.PlatformerFree.Player;

/// <summary>
/// Deals damage to the player on contact.
/// Can be used for enemies, spikes, traps, etc.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    public class TouchLife : MonoBehaviour
    {
        public float LifeAmount = 1f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var health = collision.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeLife(LifeAmount);

                }
            }
        }
    }
}