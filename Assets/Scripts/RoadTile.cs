using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : MonoBehaviour
{
    [SerializeField] float speed = 1;
    private void Update()
    {
        speed = GameManager.GlobalSpeed;
        MovingBehavior();
    }
    void MovingBehavior()
    {
        var temp = transform.position;
        temp.z -= 1;
        transform.position = Vector3.Lerp(transform.position, temp, speed * Time.deltaTime);
    }
}
