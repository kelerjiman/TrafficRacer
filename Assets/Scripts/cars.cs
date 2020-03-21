using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody),typeof(AudioSource))]
public class cars : MonoBehaviour, IPooler
{
    public float MainSpeed = 2;

    [Header("Animation Attributes")]
    [SerializeField]
    GameObject model;
    Rigidbody rig;
    //defualt Attributes
    BoxCollider m_collider;
    float m_defRot;
    Vector3 m_defPos;
    bool m_accident, stop = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("accident was accured");
            model.transform.rotation = Quaternion.Euler(0, 15 + m_defRot, 0);
            m_accident = true;
        }
    }
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        m_defPos = transform.position;
        m_defRot = model.transform.rotation.eulerAngles.y;
        m_collider = GetComponent<BoxCollider>();
        MainSpeed = GameManager.Instance.GM_MainSpeed;

    }
    private void Update()
    {
        if (!m_accident)
            Movement();
        else
        {
            if (!stop)
                OnAccident();
        }
    }
    void Movement()
    {
        transform.Translate(Vector3.forward * MainSpeed * Time.deltaTime);
    }
    void OnAccident()
    {
        rig.isKinematic = true;
        m_collider.enabled = false;
        stop = true;
    }
    public void setDefault()
    {
        rig.isKinematic = false;
        model.transform.rotation = Quaternion.Euler(0, m_defRot, 0);
        transform.position = m_defPos;
        if (m_collider != null && !m_collider.enabled)
            m_collider.enabled = true;
        stop = false;
        m_accident = false;
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
