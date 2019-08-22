using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Movement : MonoBehaviour
{
    //private Vars
    Vector3 DefPos = Vector3.zero;
    Vector3 NewPos = Vector3.zero;
    Quaternion DefRot, NewRot;
    Rigidbody rig;

    //public or Inspector Vars
    [SerializeField] float InputX_Set = 0;
    [SerializeField] float AngleY = 1f;
    [SerializeField] border GameBorder;
    [SerializeField] float MaxSpeed = 60f;

    [Header("Vehicle Properties")]
    [SerializeField]
    float Vehicle_MaxSpeed = 1f;
    [SerializeField] float Vehicle_GearCount = 4f;
    [SerializeField] float Vehicle_Wieght = 500f;

    //handling 
    [Header("Handling")]
    [SerializeField]
    [Range(0, 1)]
    float H_P_Speed = 0f;
    [Range(0, 1)]
    [SerializeField]
    float H_R_Speed = 0.5f;
    /// <summary>
    /// for Stabel Condition
    /// </summary>
    bool StableCondition = true;
    //Accident 
    [Header("accident Properties")]
    [SerializeField]
    [Tooltip("reaction velocity to player ")]
    [Range(0, 1)]
    float acc_reactionForce = 40f;
    bool IsAccident = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obs")
        {
            IsAccident = true;
            GameManager.Accident = true;

        }
    }

    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
        tag = "Player";
        GameBorder = FindObjectOfType<border>();
        if (GetComponents<MeshCollider>().Length > 0)
        {
            Component.Destroy(gameObject.GetComponent<MeshCollider>());
        }
    }
    private void FixedUpdate()
    {
        Direction();
        Handling();
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        DefPos = transform.position;
        NewPos = DefPos;
        DefRot = transform.rotation;
        NewRot = DefRot;
        NewRot = Quaternion.AngleAxis(3f, Vector3.left);

    }
    private void Update()
    {
        move();
        AccidentFunc();
        AccAndBreaking();

    }
    private void LateUpdate()
    {
    }
    void move()
    {
        if (IsAccident)
            return;

        NewPos.x += InputX_Set;
        NewPos.z += GameManager.GlobalSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, NewPos, H_P_Speed * Time.deltaTime);

    }
    void Direction()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.A))
            {
                InputX_Set = -1f;
            }
            else
            {
                InputX_Set = 1f;
            }
        }
        else
            InputX_Set = 0;
    }
    void Handling()
    {
        var temp = transform.rotation;
        temp = Quaternion.Euler(0, AngleY * InputX_Set, 0);
        NewRot = temp;
        if (InputX_Set != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, temp, H_R_Speed * Time.deltaTime);

        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, H_R_Speed * 2 * Time.deltaTime);

        }
    }

    void AccidentFunc()
    {
        if (IsAccident)
            transform.position = Vector3.Lerp(transform.position, GameBorder.transform.position, acc_reactionForce * Time.deltaTime);
    }
    void AccAndBreaking()
    {
        var temp = transform.rotation;
        if (Input.GetKey(KeyCode.W))
        {
            temp = Quaternion.Euler(-10f, temp.eulerAngles.y, temp.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, temp, H_R_Speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            temp = Quaternion.Euler(3f, temp.eulerAngles.y, temp.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, temp, H_R_Speed);

        }
    }
}

