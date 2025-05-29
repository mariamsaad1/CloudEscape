// using UnityEngine;

// public class HealthEffects : MonoBehaviour
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

public class HealthEffects : MonoBehaviour
{
    [Header("Health & Effects")]
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private Transform damageTextSpawn;


    public void ShowDamageText(float amount)
    {
        if (damageTextPrefab != null && damageTextSpawn != null)
        {
            GameObject go = Instantiate(damageTextPrefab, damageTextSpawn.position, Quaternion.identity, damageTextSpawn);
            DamageText damageText = go.GetComponent<DamageText>();
            if (damageText != null)
            {
                Debug.Log($"Show:{damageText}");
                // damageText.SetText(amount.ToString("F1"));
                damageText.SetText($"-{amount.ToString("F1")}");
                Debug.Log(amount.ToString("F1"));
            }
        }
    }

}
