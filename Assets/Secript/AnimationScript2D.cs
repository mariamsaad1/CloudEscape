// // // using UnityEngine;

// // // public class AnimationScript2D : MonoBehaviour
// // // {
// // //     // Start is called once before the first execution of Update after the MonoBehaviour is created
// // //     void Start()
// // //     {
        
// // //     }

// // //     // Update is called once per frame
// // //     void Update()
// // //     {
        
// // //     }
// // // }



// // using UnityEngine;
// // using System.Collections;

// // public class AnimationScript2D : MonoBehaviour
// // {
// //     public bool isAnimated = false;

// //     public bool isRotating = false;
// //     public bool isFloating = false;
// //     public bool isScaling = false;

// //     public float rotationSpeed;

// //     public float floatSpeed;
// //     private bool goingUp = true;
// //     public float floatRate;
// //     private float floatTimer;

// //     public Vector3 startScale;
// //     public Vector3 endScale;

// //     private bool scalingUp = true;
// //     public float scaleSpeed;
// //     public float scaleRate;
// //     private float scaleTimer;

// //     void Update()
// //     {
// //         if (isAnimated)
// //         {
// //             if (isRotating)
// //             {
// //                 // في 2D عادةً نلف حول المحور Z
// //                 transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
// //             }

// //             if (isFloating)
// //             {
// //                 floatTimer += Time.deltaTime;
// //                 Vector3 moveDir = new Vector3(0f, floatSpeed * Time.deltaTime, 0f);
// //                 transform.Translate(moveDir);

// //                 if (goingUp && floatTimer >= floatRate)
// //                 {
// //                     goingUp = false;
// //                     floatTimer = 0;
// //                     floatSpeed = -floatSpeed;
// //                 }
// //                 else if (!goingUp && floatTimer >= floatRate)
// //                 {
// //                     goingUp = true;
// //                     floatTimer = 0;
// //                     floatSpeed = -floatSpeed;
// //                 }
// //             }

// //             if (isScaling)
// //             {
// //                 scaleTimer += Time.deltaTime;

// //                 if (scalingUp)
// //                 {
// //                     transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
// //                 }
// //                 else
// //                 {
// //                     transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
// //                 }

// //                 if (scaleTimer >= scaleRate)
// //                 {
// //                     scalingUp = !scalingUp;
// //                     scaleTimer = 0;
// //                 }
// //             }
// //         }
// //     }
// // }



// using UnityEngine;

// public class AnimationScript2D : MonoBehaviour
// {
//     public bool isAnimated = false;

//     public bool isRotating = false;
//     public bool isFloating = false;
//     public bool isScaling = false;

//     [Header("Rotation Settings")]
//     public Vector3 rotationAxis = new Vector3(0f, 0f, 1f); // دوران حول Z بشكل افتراضي
//     public float rotationSpeed;

//     [Header("Floating Settings")]
//     public Vector3 floatDirection = Vector3.up; // الطيران على المحور Y بشكل افتراضي
//     public float floatSpeed;
//     public float floatRate;
//     private float floatTimer;
//     private bool goingForward = true;

//     [Header("Scaling Settings")]
//     public Vector3 startScale = Vector3.one;
//     public Vector3 endScale = Vector3.one * 1.2f;
//     public float scaleSpeed;
//     public float scaleRate;
//     private float scaleTimer;
//     private bool scalingUp = true;

//     void Update()
//     {
//         if (!isAnimated) return;

//         if (isRotating)
//         {
//             transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
//         }

//         if (isFloating)
//         {
//             floatTimer += Time.deltaTime;

//             Vector3 moveDir = floatDirection.normalized * floatSpeed * Time.deltaTime;
//             transform.Translate(moveDir);

//             if (floatTimer >= floatRate)
//             {
//                 floatDirection = -floatDirection;
//                 floatTimer = 0;
//             }
//         }

//         if (isScaling)
//         {
//             scaleTimer += Time.deltaTime;

//             if (scalingUp)
//                 transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
//             else
//                 transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);

//             if (scaleTimer >= scaleRate)
//             {
//                 scalingUp = !scalingUp;
//                 scaleTimer = 0;
//             }
//         }
//     }
// }




using UnityEngine;

public class AnimationScript2D : MonoBehaviour
{
    public bool isAnimated = false;

    public bool isRotating = false;
    public bool isFloating = false;
    public bool isScaling = false;

    [Header("Rotation Settings")]
    public Vector3 rotationAxis = new Vector3(0f, 0f, 1f); // Z فقط في 2D
    public float rotationSpeed;

    [Header("Floating Settings")]
    public Vector3 floatDirection = Vector3.up; // الافتراضي Y
    public float floatSpeed;
    public float floatRate;
    private float floatTimer;
    private bool goingForward = true;

    [Tooltip("يفعّل قلب الكائن تلقائيًا إذا كان الطيران على محور X")]
    public bool enableFlipOnX = false;
    private SpriteRenderer spriteRenderer;

    [Header("Scaling Settings")]
    public Vector3 startScale = Vector3.one;
    public Vector3 endScale = Vector3.one * 1.2f;
    public float scaleSpeed;
    public float scaleRate;
    private float scaleTimer;
    private bool scalingUp = true;

    void Start()
    {
        // نحاول الحصول على SpriteRenderer إذا كان flip مفعّل
        if (enableFlipOnX)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogWarning("SpriteRenderer not found on this GameObject.");
            }
        }
    }

    void Update()
    {
        if (!isAnimated) return;

        if (isRotating)
        {
            transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
        }

        if (isFloating)
        {
            floatTimer += Time.deltaTime;

            Vector3 moveDir = floatDirection.normalized * floatSpeed * Time.deltaTime;
            transform.Translate(moveDir);

            if (floatTimer >= floatRate)
            {
                floatDirection = -floatDirection;
                floatTimer = 0;

                // لو flip مفعّل والمحور X
                if (enableFlipOnX && Mathf.Abs(floatDirection.x) > 0.01f && spriteRenderer != null)
                {
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                }
            }
        }

        if (isScaling)
        {
            scaleTimer += Time.deltaTime;

            if (scalingUp)
                transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
            else
                transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);

            if (scaleTimer >= scaleRate)
            {
                scalingUp = !scalingUp;
                scaleTimer = 0;
            }
        }
    }
}
