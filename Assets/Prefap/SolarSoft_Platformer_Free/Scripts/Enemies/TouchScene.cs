using UnityEngine;
using SolarSoft.PlatformerFree.Player;
using UnityEngine.SceneManagement;
using System.Collections;



    public class TouchScene : MonoBehaviour
    {
        public GameObject WinUI;
        public Collider2D cubeCollider;
        public AudioSource WinSound;
        public GameObject[] objectsToDisable;

        private bool triggerEnabled = false;
        public int WinCollectibleCondition;

        public GameObject Hint;
        private bool hintShown = false;

         void Start(){
            Collectible.score=0;
         }


        void Update()
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
            if (collision.CompareTag("Player"))
            {
                if (Collectible.score == WinCollectibleCondition)
                {
                    
                    Debug.Log("Player reached the win zone");

                    WinUI.SetActive(true);
                    WinSound.Play();

                    foreach (GameObject obj in objectsToDisable)
                    {
                        obj.SetActive(false);
                    }

                }else if (!hintShown){
                    StartCoroutine(ShowHintTemporarily(3f)); // عرض التنبيه لمدة 3 ثوانٍ
                }
            }
        }
    }

