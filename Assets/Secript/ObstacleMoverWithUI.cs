using UnityEngine;

public class ObstacleMoverWithUI : MonoBehaviour
{
    // public float speed = 5f;
    public Transform player;
    public float triggerDistance = 3f;
    public GameObject uiElement;

    void Update()
    {
        // transform.Translate(Vector2.left * speed * Time.deltaTime);

        uiElement.SetActive(
            Vector2.Distance(transform.position, player.position) <= triggerDistance
        );
    }
}
