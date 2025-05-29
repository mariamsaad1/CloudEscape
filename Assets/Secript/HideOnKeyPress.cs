using UnityEngine;

public class HideOnKeyPress : MonoBehaviour
{
    public GameObject targetObject; 
    public KeyCode keyToPress = KeyCode.Space;
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            targetObject.SetActive(false);
        }
    }
}
