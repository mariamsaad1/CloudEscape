using UnityEngine;

public class HideAfterTime : MonoBehaviour
{
    public float hideTime = 3f;

    void OnEnable()
    {
        Invoke("Hide", hideTime);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}