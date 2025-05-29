using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI WinScoreText;

    public static int score = 0;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            score++;
            scoreText.text = $"{score}";
            WinScoreText.text = $"{score}";
            Destroy(gameObject);
        }
    }

    public void setScore(){
        score=0;
        Debug.Log($"score= {score}");
    }
}