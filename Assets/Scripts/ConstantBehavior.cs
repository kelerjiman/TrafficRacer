using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantBehavior : MonoBehaviour
{
    Vector3 defPos;
    GameObject player;
    [HideInInspector]
    public float NewXPos = 0;
    void Start()
    {
        defPos = transform.position;
        player = FindObjectOfType<Movement>().gameObject;
        defPos.z = defPos.z - player.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GM.GM_Is_Accident)
            transform.position =
                new Vector3(0, 0, defPos.z + player.transform.position.z);
        else
        {
            transform.position += Vector3.forward * Time.deltaTime * GameManager.GM.GM_MainSpeed;

        }
    }
}
