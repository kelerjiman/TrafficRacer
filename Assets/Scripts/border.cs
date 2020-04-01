using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
