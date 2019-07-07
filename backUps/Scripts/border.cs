using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.tag=="Player")
        {
            Time.timeScale = 0;
            print("game over");
        }
        else
        {
            if(collision.gameObject.tag!="ground")
                Destroy(collision.gameObject);
        }
    }
}
