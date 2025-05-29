using UnityEngine;

public class BatFloat : MonoBehaviour
{
    public float floatSpeed = 1f;     // سرعة الحركة
    public float floatHeight = 0.5f;  // مقدار الصعود والنزول

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
