using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages collectible stars, win condition, and win panel display.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    public class StarManager : MonoBehaviour
    {
        public static StarManager Instance;

        [Header("Star UI")]
        public Sprite collectedStarSprite;
        public Sprite uncollectedStarSprite;
        public Image[] starSlots;

        [Header("Win Handling")]
        public GameObject winPanel;
        public PlayerMovement playerMovement;

        private int starsCollected = 0;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            foreach (Image star in starSlots)
            {
                star.sprite = uncollectedStarSprite;
            }

            if (winPanel != null)
                winPanel.SetActive(false);
        }

        /// <summary>
        /// Call this when a star is collected.
        /// </summary>
        public void CollectStar()
        {
            if (starsCollected >= starSlots.Length) return;

            starSlots[starsCollected].sprite = collectedStarSprite;
            starsCollected++;

            if (starsCollected == starSlots.Length)
                Invoke(nameof(LevelComplete), 1f); // Optional delay
        }

        /// <summary>
        /// Called when all stars are collected.
        /// </summary>
        private void LevelComplete()
        {
            if (playerMovement != null)
                playerMovement.enabled = false;

            if (winPanel != null)
                winPanel.SetActive(true);
        }

        // --- UI BUTTON HOOKS ---

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}