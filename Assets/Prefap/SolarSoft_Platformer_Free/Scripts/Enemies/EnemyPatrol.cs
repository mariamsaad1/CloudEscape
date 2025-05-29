using UnityEngine;

/// <summary>
/// Basic enemy patrol behavior between two points.
/// Flips sprite based on movement direction.
/// </summary>
namespace SolarSoft.PlatformerFree
{
    public class EnemyPatrol : MonoBehaviour
    {
        public float moveSpeed = 2f;
        public Transform leftPoint;
        public Transform rightPoint;

        private bool movingRight = true;

        private void Update()
        {
            if (movingRight)
            {
                MoveTowards(rightPoint.position);

                // Face right
                transform.localScale = new Vector3(1, 1, 1);

                if (Vector2.Distance(transform.position, rightPoint.position) < 0.2f)
                    movingRight = false;
            }
            else
            {
                MoveTowards(leftPoint.position);

                // Face left
                transform.localScale = new Vector3(-1, 1, 1);

                if (Vector2.Distance(transform.position, leftPoint.position) < 0.2f)
                    movingRight = true;
            }
        }

        private void MoveTowards(Vector2 target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }

        private void OnDrawGizmosSelected()
        {
            if (leftPoint != null && rightPoint != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(leftPoint.position, 0.1f);
                Gizmos.DrawWireSphere(rightPoint.position, 0.1f);
            }
        }
    }
}