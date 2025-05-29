using UnityEngine;
using SolarSoft.PlatformerFree.Player;

/// <summary>
/// Deals damage to the player on contact.
/// Can be used for enemies, spikes, traps, etc.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    public class TouchHelp : MonoBehaviour
    {
    public float speedBoostAmount = 2f;
    public float HeightIncreaseAmount = 2f;
    public float powerupDuration = 5f;
    public HintManager x;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // زيادة سرعة اللاعب مؤقتًا
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.StartCoroutine(playerMovement.TempSpeedBoost(speedBoostAmount, powerupDuration));
            }

            // زيادة كول داون البرق مؤقتًا
            CloudLightningStrike cloud = FindObjectOfType<CloudLightningStrike>();
            if (cloud != null)
            {
                cloud.StartCoroutine(cloud.TempCooldownBoost(HeightIncreaseAmount, powerupDuration));
            }

            x.ShowHint();

            Destroy(gameObject); // حذف المكعب بعد جمعه
        }
    }
    }
}






