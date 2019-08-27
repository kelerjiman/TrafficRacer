using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Building : MonoBehaviour
{
    border GBorder;
    Rigidbody rig;
    void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Obs");
        rig = GetComponent<Rigidbody>();
        if (GetComponents<MeshCollider>().Length > 0)
        {
            Destroy(GetComponent<MeshCollider>());
        }
        GBorder = FindObjectOfType<border>();
        rig.useGravity = false;
        rig.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void OnCollisionEnter(Collision collision)
    {
    }
}
