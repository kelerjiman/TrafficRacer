using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class Car_Collision : MonoBehaviour
{
    public float XPos = 0;
    public float speed = 5;
    public Vector3 CurrentPosition = Vector3.zero;
    public bool Have_Permission_Change = true;//shoud be false--- for test must be true!!!
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Change_Area" && Have_Permission_Change)
        {
            Handle_Change_Position();
        }
    }
    private void Start()
    {
        speed = 2;
        XPos = GetComponentInParent<Spawner>().ChangeLine_Xpos;
        CurrentPosition = transform.position;
    }
    private void Update()
    {
        CurrentPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, CurrentPosition, speed * Time.deltaTime);
    }
    private void Handle_Change_Position()
    {
        CurrentPosition.x += XPos;
        Have_Permission_Change = false;
    }
}
