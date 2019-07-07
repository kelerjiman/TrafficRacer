using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public float zSpeed = -30f;
    [Range(0, 1)]
    public float Speed = 0.5f;
    border GBorder;
    void Start()
    {
        gameObject.AddComponent<BoxCollider>().enabled = true;
        if (GetComponents<MeshCollider>().Length > 0)
        {
            Destroy(GetComponent<MeshCollider>());
        }
        GBorder = FindObjectOfType<border>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(zSpeed * Time.deltaTime, 0, 0);
    }
}
