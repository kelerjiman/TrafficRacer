using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderLightColliders : MonoBehaviour
{
    public bool DirClosed = false, FrontClosed = false;
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.gameObject.layer!=LayerMask.NameToLayer("Ground"))
        {
            DirClosed = true;
            if (name == "Front")
                GetComponentInParent<LightManager>().FrontObject = other.gameObject;
            if (name == "Right")
                GetComponentInParent<LightManager>().RightObject = other.gameObject;
            if (name == "Left")
                GetComponentInParent<LightManager>().LeftObject = other.gameObject;
            if (name == "Back")
                GetComponentInParent<LightManager>().BackObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Delay());
        if (other.tag != "ground")
        {
            DirClosed = false;
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }
}
