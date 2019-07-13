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
        Parent.OnEnterHandle();
    }
    private void OnTriggerStay(Collider other)
    {
        Parent.OnStayHandle();
    }
    private void OnTriggerExit(Collider collision)
    {
        Parent.OnExitHandle();
    }
}
