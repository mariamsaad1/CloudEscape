using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    // public string SceneName;
    public void LoadScene()
    {
        SceneManager.LoadScene("1");
    }



     public void LoadScene1(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }



}
