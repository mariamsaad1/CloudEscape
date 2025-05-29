using UnityEngine;
using SolarSoft.PlatformerFree.Checkpoints;

/// <summary>
/// Defines a checkpoint location that can be activated when the player touches it.
/// Stores position using CheckpointManager.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    [RequireComponent(typeof(Collider2D))]
    public class Checkpoint : MonoBehaviour
    {
        public AudioSource sound;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                // Store this checkpoint's position
                CheckpointManager.SetCheckpoint(transform.position);
                sound.Play();
            }
        }
    }
}