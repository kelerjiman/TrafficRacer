using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class cars : MonoBehaviour
{
    public float MainSpeed = 8;
    Rigidbody rig;
    private float m_MainSpeed = 0;
    private Vector2 m_speed_range = new Vector2(0, 5);
    private void Start()
    {
        m_MainSpeed = Mathf.Sign(MainSpeed) * Random.Range(m_speed_range.x, m_speed_range.y) + MainSpeed;
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MoveHandle();
    }
    void MoveHandle()
    {
        rig.velocity = Vector3.forward * m_MainSpeed;
    }
}
#region OldCode

//public float Zspeed = -2f, DefaultSpeed, ChangeLineSpeed;
//[SerializeField]
//[Range(0, 1)]
//float H_R_Speed = 1f;
//Quaternion NewRot;
//[SerializeField] Transform RotationChild;
//public bool Inverse = false;
//Rigidbody rig;
//public bool TimeToTurn = false, NoWay = false, GoLeft = false, GoRight = false, KnowDir = false;
//[SerializeField] LightManager Detector;
//[Header("will delete after complete")]
//[SerializeField]
//GameObject front, back;
//private void Start()
//{
//    gameObject.layer = LayerMask.NameToLayer("Cars");
//    RotationChild = transform.Find("RotationChild");
//    NewRot = transform.rotation;
//    ChangeLineSpeed = GameManager.ChangeLineSpeed;
//    DefaultSpeed = Zspeed;
//    Detector = transform.Find("Detector").GetComponent<LightManager>();
//}

//private void Update()
//{
//    if (Detector.front.DirClosed)
//        TimeToTurn = true;
//    else
//        TimeToTurn = false;

//    LetsMove();
//    AIMoveBehavior();
//    AIChooseDirection();
//    ChangeDirection();
//}
//void AIMoveBehavior()
//{
//    if (Detector.front.DirClosed && Detector.FrontObject != null)
//    {
//        if (Detector.FrontObject.layer == LayerMask.NameToLayer("Cars"))
//            Zspeed = Detector.FrontObject.GetComponent<cars>().Zspeed;
//    }
//    else
//        Zspeed = DefaultSpeed;
//}
//void AIChooseDirection()
//{
//    if (!TimeToTurn)
//    {
//        KnowDir = false;
//        GoRight = false;
//        GoLeft = false;
//        return;
//    }
//    if (!KnowDir)
//    {
//        if (!Detector.left.DirClosed || !Detector.right.DirClosed)
//        {

//            NoWay = false;
//            if (!Detector.left.DirClosed)
//            {
//                KnowDir = true;
//                GoLeft = true;
//                GoRight = false;

//            }
//            else
//            {
//                KnowDir = true;
//                GoRight = true;
//                GoLeft = false;

//            }
//        }
//        else
//        {
//            GoLeft = false;
//            GoRight = false;
//            NoWay = true;
//            KnowDir = false;
//        }
//    }

//}
//void ChangeDirection()
//{
//    if (!NoWay)
//    {
//        if (GoLeft && !Detector.left.DirClosed)
//            transform.position -= Vector3.left * Time.deltaTime * ChangeLineSpeed;
//        else
//        if (GoRight && !Detector.right.DirClosed)
//            transform.position -= Vector3.right * Time.deltaTime * ChangeLineSpeed;
//        else
//            KnowDir = false;
//    }
//}

//void LetsMove()
//{
//    transform.Translate(0, 0, Zspeed * Time.deltaTime);
//}
#endregion
