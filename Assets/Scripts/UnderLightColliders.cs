using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderLightColliders : MonoBehaviour
{
    public bool DirClosed = false, FrontClosed = false;
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag != "ground")
        {
            DirClosed = true;
            if (name == "Front")
                GetComponentInParent<LightManager>().FrontObject = other.gameObject;
            if (name == "Right")
                GetComponentInParent<LightManager>().RightCar = other.gameObject;
            if (name == "Left")
                GetComponentInParent<LightManager>().LeftCar = other.gameObject;
            if (name == "Back")
                GetComponentInParent<LightManager>().BackCar = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "ground")
        {
            DirClosed = false;
        }
    }
}
