using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Building : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3(2, 2, 2);
        GetComponentInParent<BoxCollider>().size = GetComponent<BoxCollider>().size;
    }
}
