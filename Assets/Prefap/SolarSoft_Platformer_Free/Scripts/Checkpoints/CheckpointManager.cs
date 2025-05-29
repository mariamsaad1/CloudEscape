using UnityEngine;

namespace SolarSoft.PlatformerFree.Checkpoints
{
    /// <summary>
    /// Manages the active checkpoint's position.
    /// Provides static methods for setting and retrieving the checkpoint.
    /// </summary>
    public static class CheckpointManager
    {
        private static Vector3 checkpointPosition;
        private static bool hasCheckpoint = false;

        /// <summary>
        /// Stores the checkpoint position and marks it as active.
        /// </summary>
        /// <param name="position">The world position of the checkpoint.</param>
        public static void SetCheckpoint(Vector3 position)
        {
            checkpointPosition = position;
            hasCheckpoint = true;
        }

        /// <summary>
        /// Returns true if a checkpoint has been set.
        /// </summary>
        public static bool HasCheckpoint() => hasCheckpoint;

        /// <summary>
        /// Gets the stored checkpoint position.
        /// </summary>
        public static Vector3 GetCheckpoint() => checkpointPosition;

        /// <summary>
        /// Resets the checkpoint data.
        /// </summary>
        public static void ResetCheckpoint()
        {
            hasCheckpoint = false;
            checkpointPosition = Vector3.zero;
        }
    }
}