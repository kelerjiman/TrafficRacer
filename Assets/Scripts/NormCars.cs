using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class NormCars : MonoBehaviour
{
    public float MainSpeed = 8;
    Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void MoveHandle()
    {
        rig.velocity = Vector3.forward * MainSpeed;
    }
}
