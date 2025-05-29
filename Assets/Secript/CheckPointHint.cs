using UnityEngine;
using System.Collections;


public class CheckPointHint : MonoBehaviour
{
    public GameObject Hint;
    private bool hintShown = false;


    void Start()
    {
        
    }


    IEnumerator ShowHintTemporarily(float duration)
        {
            hintShown = true;
            Hint.SetActive(true);
            yield return new WaitForSeconds(duration);
            Hint.SetActive(false);
            hintShown = false;
           
        } 
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("in Collison");
            if (collision.CompareTag("Player")){
                Debug.Log("with Player");
           
             if (!hintShown){
                    StartCoroutine(ShowHintTemporarily(3f)); // عرض التنبيه لمدة 3 ثوانٍ
                    Debug.Log("display");
                }

        }
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
