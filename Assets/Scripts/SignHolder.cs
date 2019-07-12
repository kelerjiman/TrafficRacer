using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignHolder : MonoBehaviour
{
    [SerializeField] SignBehavior Parent;
    private void Start()
    {
        Parent = GetComponentInParent<SignBehavior>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Parent
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider collision)
    {

    }
}
