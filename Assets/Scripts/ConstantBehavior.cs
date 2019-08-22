using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantBehavior : MonoBehaviour
{
    Vector3 defPos;
    GameObject player;
    void Start()
    {
        defPos = transform.position;
        player = FindObjectOfType<Movement>().gameObject;
        defPos.z = defPos.z - player.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Accident)
        transform.position = new Vector3(transform.position.x, transform.position.y, defPos.z + player.transform.position.z);
    }
}
