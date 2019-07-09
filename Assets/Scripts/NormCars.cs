using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormCars : MonoBehaviour
{
    public float Zspeed = -2f, DefaultSpeed, ChangeLineSpeed;
    [SerializeField]
    [Range(0, 1)]
    float H_R_Speed = 1f;
    Quaternion NewRot;
    [SerializeField] Transform RotationChild;
    border GBorder;
    Rigidbody rig;
    [SerializeField] bool TimeToTurn = false, NoWay = false, GoLeft = false, GoRight = false, KnowDir = false;
    [SerializeField] LightManager Detector;
    [Header("will delete after complete")]
    [SerializeField]
    GameObject front, back;
    [SerializeField]
    float angle = 30f;
    private void Start()
    {
        RotationChild = transform.Find("RotationChild");
        NewRot = transform.rotation;
        ChangeLineSpeed = GameManager.ChangeLineSpeed;
        DefaultSpeed = Zspeed;
        Detector = transform.Find("Detector").GetComponent<LightManager>();
    }

    private void Update()
    {
        if (Detector.front.DirClosed)
            TimeToTurn = true;
        else
            TimeToTurn = false;

        LetsMove();
        AIMoveBehavior();
        AIChooseDirection();
        ChangeDirection();
    }
    void AIMoveBehavior()
    {
        if (Detector.back.DirClosed && Detector.BackObject != null)
        {
            if (Detector.BackObject.layer == LayerMask.NameToLayer("Cars"))
                Zspeed = Detector.BackObject.GetComponent<NormCars>().Zspeed;
        }
        else
            Zspeed = DefaultSpeed;
    }
    void AIChooseDirection()
    {
        if (!TimeToTurn)
        {
            KnowDir = false;
            GoRight = false;
            GoLeft = false;
            return;
        }
        if (!KnowDir)
        {
            if (!Detector.left.DirClosed || !Detector.right.DirClosed)
            {

                NoWay = false;
                if (!Detector.left.DirClosed)
                {
                    KnowDir = true;
                    GoLeft = true;
                    GoRight = false;

                }
                else
                {
                    KnowDir = true;
                    GoRight = true;
                    GoLeft = false;

                }
            }
            else
            {
                GoLeft = false;
                GoRight = false;
                NoWay = true;
                KnowDir = false;
            }
        }

    }
    void ChangeDirection()
    {
        if (!NoWay)
        {
            if (GoLeft && !Detector.left.DirClosed)
                transform.position += Vector3.left * Time.deltaTime * ChangeLineSpeed;
            else
            if (GoRight && !Detector.right.DirClosed)
                transform.position += Vector3.right * Time.deltaTime * ChangeLineSpeed;
            else
                KnowDir = false;
        }
    }

    void LetsMove()
    {
        transform.Translate(0, 0, Zspeed * Time.deltaTime);
    }
}
