using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class SignHolder : MonoBehaviour
{

    public Vector3 ColliderSize = Vector3.zero;
    public Vector3 ColliderCenter = Vector3.zero;
    BoxCollider BCollider;
    SignBehavior Parent;


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
    private void Awake()
    {
        Parent = GetComponentInParent<SignBehavior>();

    }
    private void Start()
    {
        BCollider = GetComponent<BoxCollider>();
        BColliderReload();
    }

    //For Changing the laws and other thing we need the reset the colliders size for
    //example in one line street the x value of collider size we need 4 unit and on 2 lines we need 8 unit for x value
    void BColliderReload()
    {
        BCollider.size = ColliderSize;
        BCollider.center = ColliderCenter;
    }
}
