// // using UnityEngine;

// // public class CloudLightningStrike : MonoBehaviour
// // {
// //     // Start is called once before the first execution of Update after the MonoBehaviour is created
// //     void Start()
// //     {
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// // }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class CloudLightningStrike : MonoBehaviour
// {
//       public Transform player;       // مرجع لكائن اللاعب
//     public float speed = 2f;       // سرعة حركة السحابة
//     public float lightningDistance = 1.5f; // المسافة لإطلاق البرق
//     public GameObject lightningPrefab; // كائن البرق
//     public float cooldown = 3f;    // فترة الانتظار بين ضربات البرق
//     public float yOffset = 2f;     // المسافة التي ستكون السحابة أعلى من اللاعب (تأكد أن القيمة إيجابية)
//     public float riseHeight = 1f;  // الارتفاع الذي سترتفعه السحابة بعد ضرب البرق

//     private bool canStrike = true; // للتحقق من إمكانية ضرب البرق
//     private bool isRising = false; // للتحقق إذا كانت السحابة في مرحلة الارتفاع
//     private float riseTime = 2f;   // وقت الارتفاع (2 ثانية)
//     private float riseTimer = 0f;  // عداد الوقت للارتفاع

//     void Update()
//     {
//         if (player != null)
//         {
//             // إذا كانت السحابة في مرحلة الارتفاع
//             if (isRising)
//             {
//                 riseTimer += Time.deltaTime;
//                 if (riseTimer < riseTime)
//                 {
//                     // السحابة ترتفع تدريجياً
//                     transform.position = new Vector2(transform.position.x, transform.position.y + (riseHeight / riseTime) * Time.deltaTime);
//                 }
//                 else
//                 {
//                     // بعد 2 ثانية، تبدأ السحابة بالعودة إلى الأسفل
//                     isRising = false;
//                     riseTimer = 0f;
//                 }
//             }
//             else
//             {
//                 // تحريك السحابة نحو اللاعب مع تعويض المسافة على الـ Y
//                 Vector2 targetPosition = new Vector2(player.position.x, player.position.y + yOffset);
//                 Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
//                 transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
//             }

//             // التحقق من المسافة وضرب البرق
//             if (Vector2.Distance(transform.position, player.position) <= lightningDistance && canStrike)
//             {
//                 StartCoroutine(StrikeLightning());
//             }
//         }
//     }

//     private IEnumerator StrikeLightning()
//     {
//         canStrike = false;
//         // تفعيل البرق
//         // GameObject lightning = Instantiate(lightningPrefab, player.position, Quaternion.identity);
// GameObject lightning = Instantiate(lightningPrefab, new Vector2(player.position.x, player.position.y + 1.5f), Quaternion.identity);

//         yield return new WaitForSeconds(0.5f); // مدة البرق
//         Destroy(lightning);

//         // بعد ضرب البرق، السحابة ترتفع وتعود بعد 2 ثانية
//         isRising = true;
//         yield return new WaitForSeconds(2f); // وقت الانتظار قبل النزول
//         canStrike = true;
//     }
// }




public class CloudLightningStrike : MonoBehaviour
{
    // public static bool StartGame=false;
    public Transform player;
    public float speed = 2f;
    public float lightningDistance = 1.5f;
    public GameObject lightningPrefab;
    public float cooldown = 3f;
    public float yOffset = 2f;
    public float riseHeight = 1f;

    // private bool canStrike = true;
    public bool canStrike = false;
    private bool isRising = false;
    private float riseTime = 2f;
    private float riseTimer = 0f;

    public AudioClip lightningSound; // <-- مؤثر صوت البرق
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // تأكد أن الكائن يحتوي على AudioSource
    }

    // void Update()
    // {
    //     if (player != null)
    //     {
    //         if (isRising)
    //         {
    //             riseTimer += Time.deltaTime;
    //             if (riseTimer < riseTime)
    //             {
    //                 transform.position = new Vector2(transform.position.x, transform.position.y + (riseHeight / riseTime) * Time.deltaTime);
    //             }
    //             else
    //             {
    //                 isRising = false;
    //                 riseTimer = 0f;
    //             }
    //         }
    //         else
    //         {
    //             Vector2 targetPosition = new Vector2(player.position.x, player.position.y + yOffset);
    //             Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
    //             transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    //         }

    //         if (Vector2.Distance(transform.position, player.position) <= lightningDistance && canStrike)
    //         {
    //             StartCoroutine(StrikeLightning());
    //         }
    //     }
    // }


void Update()
{
    if (player != null)
    {
        if (isRising)
        {
            riseTimer += Time.deltaTime;
            if (riseTimer < riseTime)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + (riseHeight / riseTime) * Time.deltaTime);
            }
            else
            {
                isRising = false;
                riseTimer = 0f;
            }
        }
        else
        {
            Vector2 targetPosition = new Vector2(player.position.x, player.position.y + yOffset);
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        // التحقق من أن اللاعب تحت الغيمة أفقيًا وضمن المسافة
        float horizontalDistance = Mathf.Abs(transform.position.x - player.position.x);
        float verticalDistance = Mathf.Abs(transform.position.y - (player.position.y + yOffset));

        if (horizontalDistance <= lightningDistance && verticalDistance <= lightningDistance && canStrike)
        {
            StartCoroutine(StrikeLightning());
        }
    }
}


    private IEnumerator StrikeLightning()
    {
        canStrike = false;

        // شغّل صوت البرق
        if (lightningSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(lightningSound);
        }

        GameObject lightning = Instantiate(lightningPrefab, new Vector2(player.position.x, player.position.y + 1.5f), Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        Destroy(lightning);

        isRising = true;
        yield return new WaitForSeconds(2f);
        canStrike = true;
    }



public IEnumerator TempCooldownBoost(float extraCooldown, float duration)
{
    speed -= extraCooldown;
    yield return new WaitForSeconds(duration);
    speed += extraCooldown;
}

public void SetCanStrike(bool value)
{
    canStrike = value;
}

}
