using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SImage : MonoBehaviour
{
    public Material G_Materials;
    private void Start()
    {
        GetComponent<Renderer>().material = G_Materials;
    }
}
