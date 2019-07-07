using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public float zSpeed = -2f;
    void Start()
    {
        gameObject.tag = "Obs";
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(zSpeed, 0, 0);
    }
}
