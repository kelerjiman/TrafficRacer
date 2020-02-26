using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    ObjectPooler OP;
    // Start is called before the first frame update
    void Start()
    {
        OP = GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var x = OP.SpawnFromPool(transform.position, Quaternion.identity);
        }
    }
}
