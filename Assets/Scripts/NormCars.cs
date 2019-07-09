using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormCars : MonoBehaviour
{
    public float Zspeed = -2f, DefaultSpeed;
    [SerializeField]
    [Range(0, 1)]
    float H_R_Speed = 1f;
    Quaternion defRot;
    public bool Inverse = false;
    border GBorder;
    Rigidbody rig;
    [SerializeField] bool TimeToTurn = false, NoWay = false;
    [SerializeField] LightManager lights;
    [Header("will delete after complete")]
    [SerializeField]
    GameObject front, back;
    [SerializeField]
    float angle = 30f;

    private void Update()
    {
        if (lights.front.DirClosed)
            TimeToTurn = true;
        else
            TimeToTurn = false;

        LetsMove();
        //AIMoveBehavior();
    }
    void AIMoveBehavior()
    {
        if (lights.back.DirClosed)
            Zspeed = lights.BackObject.GetComponent<NormCars>().Zspeed;
        else
            Zspeed = DefaultSpeed;
    }
    void AIChooseDirection()
    {
        if (!TimeToTurn) return;
        if (!lights.left.DirClosed || !lights.right.DirClosed)
        {
            if (!lights.left.DirClosed)
            {

            }
            else
            {

            }
        }
    }

    void LetsMove()
    {
        transform.Translate(0, 0, Zspeed * Time.deltaTime);
    }
}
