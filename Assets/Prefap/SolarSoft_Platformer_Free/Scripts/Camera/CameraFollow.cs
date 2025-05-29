using UnityEngine;

/// <summary>
/// Simple camera follow behavior for 2D platformers.
/// Smoothly follows the target with optional positional offset.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Follow Target")]
        [Tooltip("The transform the camera will follow (e.g. the player).")]
        public Transform target;

        [Header("Position Settings")]
        [Tooltip("Offset from the target position.")]
        public Vector3 offset = new Vector3(0f, 0f, -10f);

        [Tooltip("Smoothing factor for the camera movement.")]
        public float smoothSpeed = 5f;

        private void LateUpdate()
        {
            if (target == null) return;

            // Calculate desired camera position
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Apply the final position
            transform.position = smoothedPosition;
        }
    }
}