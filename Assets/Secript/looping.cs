using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public float speed = 10f;
    public float tileWidth = 11f; // عرض بلاطة الأرضية
    public Transform player;

    void Update()
    {
        // حرك الأرضية
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // إذا البلاطة طلعت من ورا اللاعب، رجعها قدام
        if (transform.position.x < player.position.x - tileWidth)
        {
            float newX = transform.position.x + tileWidth * 2; // حركها قدام البلاطتين
            transform.position = new Vector2(newX, transform.position.y);
        }
    }
}
