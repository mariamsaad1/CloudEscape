using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneSimple : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            SceneManager.LoadScene("start");
    }
}
