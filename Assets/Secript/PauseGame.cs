using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


public void PauseGameAndTime(){

    if (Collectible.score!=0){
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    
}
    
}
