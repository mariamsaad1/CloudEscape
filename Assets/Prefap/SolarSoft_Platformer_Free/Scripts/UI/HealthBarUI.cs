using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the health bar fill based on current player health.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    public class HealthBarUI : MonoBehaviour
    {
        public Image fillImage;

        /// <summary>
        /// Updates the UI health fill.
        /// </summary>
        public void UpdateHealth(float current, float max)
        {
            fillImage.fillAmount = current / max;
        }
    }
}