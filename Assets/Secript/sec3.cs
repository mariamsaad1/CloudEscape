using UnityEngine;

public class PopupDelay : MonoBehaviour
{
    public float delayBeforeShow = 3f; // وقت الانتظار قبل الظهور
    public float showDuration = 2f;    // وقت بقاء العنصر ظاهرًا

    void Start()
    {
        gameObject.SetActive(false);           // نبدأ مخفي
        Invoke("ShowBox", delayBeforeShow);    // نظهر بعد 3 ثواني
    }

    void ShowBox()
    {
        gameObject.SetActive(true);            // نظهر العنصر
        Invoke("HideBox", showDuration);       // ننتظر ثانيتين ثم نخفيه
    }

    void HideBox()
    {
        gameObject.SetActive(false);           // نخفي العنصر
    }
}
