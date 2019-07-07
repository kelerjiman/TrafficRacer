using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    //private Vars
    CharacterController ChController;
    Vector3 DefPos = Vector3.zero;
    Vector3 NewPos = Vector3.zero;
    Quaternion DefRot, NewRot;
    Rigidbody rig;


    //public or Inspector Vars
    [SerializeField] float InputX, InputX_Set = 0;
    [SerializeField] float AngleY = 1f;

    [Header("velocity for handle Gravity")]
    [SerializeField]
    float Custome_Gravity = -15f;

    [Header("Vehicle Properties")]
    [SerializeField]
    float Vehicle_MaxSpeed = 1f;
    [SerializeField] float Vehicle_GearCount = 4f;
    [SerializeField] float Vehicle_Wieght = 500f;

    //handling 
    [Header("Handling")]
    [SerializeField]
    [Range(0, 180)]
    float H_P_Speed = 0f;
    [Range(0, 1)]
    [SerializeField]
    float H_R_Speed = 0.5f;
    /// <summary>
    /// for Stabel Condition
    /// </summary>
    bool StableCondition = true;
    //breaking
    [Header("Breaking Properties")]
    [Tooltip("Percentage effect on global speed")]
    [Range(0, 1)]
    [SerializeField]
    float reactionForce = 0.5f;
    bool BrakingTriggered = false;
    //Accident 
    [Header("accident Properties")]
    [SerializeField]
    [Tooltip("reaction velocity to player ")]
    float acc_reactionForce = -40f;
    bool IsAccident = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obs")
        {
            print(collision.gameObject.name);
            IsAccident = true;
            AccidentFunc();
        }
    }

    private void Awake()
    {
    }
    private void FixedUpdate()
    {
        Direction();
    }
    private void Start()
    {
        tag = "Player";
        rig = GetComponent<Rigidbody>();
        ChController = GetComponent<CharacterController>();
        NewPos = transform.position;
        DefPos = transform.position;
        DefRot = transform.rotation;
        NewRot = transform.rotation;

    }
    private void Update()
    {
        //keepGrounded();
        move();
    }
    void move()
    {
        if (IsAccident)
            return;
        InputX = InputX_Set * Time.deltaTime;
        NewPos.x += InputX * H_P_Speed;
        transform.position = NewPos;
        Handling();
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
        if (InputX_Set != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, temp, H_R_Speed);

        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, H_R_Speed);

        }
    }
    void keepGrounded()
    {
        var temp = transform.position;
        if (temp.y != DefPos.y)
        {
            temp.y = DefPos.y;
        }
        transform.position = temp;
    }
     void AccidentFunc()
    {
        transform.Translate(Vector3.back * acc_reactionForce);
    }
}
/*
 
    [Header("Crash Properties")]
    [SerializeField]
    float zForce = 15f;
    [Range(0, 1)]
    public float Handling = 0.5f;
    [Range(0, 1)]
    [SerializeField]
    float RotationSpeed = 0.5f, RotateX, RotateY, RotateZ = 0f;
    [SerializeField] Quaternion MaxAngle;
    public float Speed = 0f;
    float inputX;
    float inputX_Set = 0f;

    Vector3 newPos = Vector3.zero;
    Quaternion DefaultRot;
    Quaternion NewRot;
    Rigidbody rig;

    bool accident = false;
    private void OnCollisionEnter(Collision collision)
    {
        CollisionBehavior(collision);
    }
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        DefaultRot = transform.rotation;
        NewRot = transform.rotation;
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        accidentCondition();
    }
    void CollisionBehavior(Collision coll)
    {
        print(LayerMask.GetMask("Obs"));
        if (coll.gameObject.layer == 9)
        {
            accident = true;
        };
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D))
            {
                inputX_Set = 1f;

            }
            else
            {
                inputX_Set = -1f;
            }
                NewRot.y += inputX_Set*Time.deltaTime;
        }
        else
        {
            inputX_Set = 0f;
            NewRot = DefaultRot;
        }
        //the 3 blow lines of code dont let the game object to move another position  
        if (!accident)
            changePosition();
        ChangeRotation();
    }

    void ChangeRotation()
    {
        if (transform.rotation.y > DefaultRot.y + MaxAngle.y)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, DefaultRot, RotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, RotationSpeed);
        }
    }

    void changePosition()
    {
        inputX = Mathf.Lerp(inputX, inputX_Set, Handling);
        newPos.x += inputX;
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
    void accidentCondition()
    {
        if (!accident)
            return;
        rig.velocity = new Vector3(0, 0, zForce);
    }
     */
