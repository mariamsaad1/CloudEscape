using UnityEngine;

public class FlagWin : MonoBehaviour
{
    public GameObject winUI; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winUI.SetActive(true); 
            Time.timeScale = 0f;   
        }
    }
}
