// using UnityEngine;

// public class HintManager : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }



using UnityEngine;
using System.Collections;


// public class HintManager : MonoBehaviour
// {
//     public GameObject magicHintPanel; // ضع هنا العنصر اللي يحتوي على الصورة


//     private IEnumerator ShowHintCoroutine()
//     {
//         magicHintPanel.SetActive(true);
//         yield return new WaitForSeconds(3f);
//         magicHintPanel.SetActive(false);
//     }



//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             StartCoroutine(ShowHintCoroutine());
//         }
//     }
    
// }





// public class HintManager : MonoBehaviour
// {
//     public GameObject magicHintPanel; // ضع هنا العنصر اللي يحتوي على الصورة

//     // private IEnumerator ShowHintCoroutine()
//     // {
//     //     // تحقق إذا كان الـ magicHintPanel مفعل
//     //     Debug.Log("Showing hint");
//     //     magicHintPanel.SetActive(true);
//     //     yield return new WaitForSeconds(3f); // مدة العرض
//     //     magicHintPanel.SetActive(false);
//     //     Debug.Log("Hiding hint");
//     // }

//     private IEnumerator ShowHintCoroutine()
// {
//     if (magicHintPanel != null)
//     {
//         magicHintPanel.SetActive(true);
//         Debug.Log("Hint shown");

//         // عد تنازلي في الـ Console
//         float waitTime = 7f;
//         while (waitTime > 0)
//         {
//             Debug.Log($"Hiding in {waitTime} seconds...");
//             yield return new WaitForSeconds(1f);
//             waitTime--;
//         }

//         magicHintPanel.SetActive(false);
//         Debug.Log("Hint hidden");
//     }
//     else
//     {
//         Debug.LogError("magicHintPanel is not assigned!");
//     }
// }


//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("Player entered trigger");
//             StartCoroutine(ShowHintCoroutine());
//         }
//     }
// }



public class HintManager : MonoBehaviour
{
    public GameObject magicHintPanel;

    public void ShowHint()
    {
        StartCoroutine(ShowHintCoroutine());
    }

    private IEnumerator ShowHintCoroutine()
    {
        magicHintPanel.SetActive(true);
        yield return new WaitForSeconds(7f);
        magicHintPanel.SetActive(false);
    }
}