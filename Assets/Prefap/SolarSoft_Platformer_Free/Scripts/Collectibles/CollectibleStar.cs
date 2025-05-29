using UnityEngine;

/// <summary>
/// Handles star collectible behavior.
/// Notifies the StarManager when collected, then disables itself.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    public class CollectibleStar : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StarManager.Instance.CollectStar();
                gameObject.SetActive(false); // Acts as simple object pooling
            }
        }
    }
}