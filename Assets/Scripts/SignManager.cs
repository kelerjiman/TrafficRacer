using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignManager : MonoBehaviour
{
    [SerializeField] GameObject SignSpawner;
    /// <summary>
    /// signs :
    /// 1- circle
    /// 2-triangle
    /// 3-info
    /// </summary>
    [SerializeField] SignBehavior[] Sign;
    /// <summary>
    /// images for sign 
    /// </summary>
    [SerializeField] Material[] signImage;
    /// <summary>
    /// area of the sign
    /// </summary>
    [SerializeField] Vector3 ColliderSize;
    /// <summary>
    /// set the line of sign`s effect
    /// </summary>
    [SerializeField] Vector3 ColliderCenter;
    /// <summary>
    /// message for the sign
    /// </summary>
    [SerializeField] string Message;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InstantiateSign();
        }
    }
    void InstantiateSign()
    {
    }
    Material SignImageSelector()
    {
        return signImage[Random.Range(0, signImage.Length)];
    }
}
