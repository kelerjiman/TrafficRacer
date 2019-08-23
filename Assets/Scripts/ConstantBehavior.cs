using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantBehavior : MonoBehaviour
{
    Vector3 defPos;
    GameObject player;
    public float NewXPos = 0;
    public float speed = 2;
    void Start()
    {
        defPos = transform.position;
        player = FindObjectOfType<Movement>().gameObject;
        defPos.z = defPos.z - player.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Is_Accident)
            transform.position =
                new Vector3(defPos.x,
                transform.position.y, defPos.z + player.transform.position.z);
        if (transform.position.x != NewXPos)
        {
            defPos.x = Mathf.Lerp(defPos.x, NewXPos, speed * Time.deltaTime);

        }
    }
}
