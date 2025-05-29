// using UnityEngine;

// public class OP : MonoBehaviour
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

public class UITriggerManager : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 3f;
    public ObstacleUI[] obstacles;

    void Update()
    {
        foreach (var obstacle in obstacles)
        {
            float distance = Vector3.Distance(obstacle.transform.position, player.position);
            obstacle.uiElement.SetActive(distance <= triggerDistance);
        }
    }
}

[System.Serializable]
public class ObstacleUI
{
    public Transform transform;
    public GameObject uiElement;
}

