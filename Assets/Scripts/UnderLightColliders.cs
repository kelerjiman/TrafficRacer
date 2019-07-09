using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderLightColliders : MonoBehaviour
{
    public bool DirClosed = false;
    public GameObject DirObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            DirClosed = true;
            DirObject = other.gameObject;
            //if (name == "Front")
            //    GetComponentInParent<LightManager>().FrontObject = other.gameObject;
            //if (name == "Right")
            //    GetComponentInParent<LightManager>().RightObject = other.gameObject;
            //if (name == "Left")
            //    GetComponentInParent<LightManager>().LeftObject = other.gameObject;
            //if (name == "Back")
            //    GetComponentInParent<LightManager>().BackObject = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            DirClosed = true;
            DirObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Delay());
        if (other.tag != "ground")
        {
            DirClosed = false;
            DirObject = null;

        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }
}
