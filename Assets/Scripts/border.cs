using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Time.timeScale = 0;
        }
        else
        {
                Destroy(collision.gameObject);
        }
    }
}
