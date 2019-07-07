using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class cars : MonoBehaviour
{// Start is called before the first frame update
    public float Zspeed = -2f, DefaultSpeed;
    [SerializeField]
    [Range(0, 1)]
    float H_R_Speed = 0.5f;
    Quaternion defRot;
    public bool Inverse = false;
    border GBorder;
    Rigidbody rig;
    [SerializeField] bool TimeToTurn = false, stop = false;
    [SerializeField] LightManager lights;
    [Header("will delete after complete")]
    [SerializeField]
    GameObject front, back;
    [SerializeField]
    float angle = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ground")
            stop = true;
    }
    void Start()
    {
        if (gameObject.GetComponents<BoxCollider>().Length == 0)
            gameObject.AddComponent<BoxCollider>().enabled = true;
        if (gameObject.GetComponents<MeshCollider>().Length > 0)
            Destroy(GetComponent<MeshCollider>());
        rig = GetComponent<Rigidbody>();
        rig.useGravity = true;
        GBorder = FindObjectOfType<border>();
        DefaultSpeed = Zspeed;
        lights = transform.Find("Lights").GetComponent<LightManager>();
        defRot = transform.rotation;
        if (Inverse)
        {
            defRot = Quaternion.LookRotation(GBorder.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AIMoveBehavior();
        AIChooseDirection();
    }

    void AIMoveBehavior()
    {
        if (lights.front.DirClosed == true)
            TimeToTurn = true;
        else
            TimeToTurn = false;
    }
    void AIChooseDirection()
    {
        //badan rooye An kar shavad
        if (TimeToTurn)
        {
            front = lights.FrontCar;
            if (front.gameObject != null && front.gameObject.activeInHierarchy)
                Zspeed = front.GetComponent<cars>().Zspeed+0.1f;
            if (Inverse)
            {
                if (!lights.left.DirClosed || !lights.right.DirClosed)
                {
                    var temp = transform.rotation;
                    if (!lights.left.DirClosed)
                    {
                        temp = Quaternion.Euler(0, transform.rotation.eulerAngles.y - angle * Time.deltaTime, 0);
                    }
                    else
                    if (!lights.right.DirClosed)
                    {
                        temp = Quaternion.Euler(0, transform.rotation.eulerAngles.y + angle * Time.deltaTime, 0);

                    }
                    transform.rotation = new Quaternion(temp.x, temp.y, temp.z, temp.w);
                    LetsMove();
                }
            }
            else
            {
                if (lights.back.DirClosed)
                {
                    Zspeed = lights.BackCar.GetComponent<cars>().Zspeed+0.1f;
                }
                else
                {
                    Zspeed = DefaultSpeed;
                }
               if(!lights.left.DirClosed|| !lights.right.DirClosed)
                {
                    var temp = transform.rotation;
                    if (!lights.left.DirClosed)
                    {
                        temp = Quaternion.Euler(0, transform.rotation.eulerAngles.y - angle * Time.deltaTime, 0);
                        transform.Translate(Vector3.left * Zspeed * Time.deltaTime);
                    }
                    else
                    if (!lights.right.DirClosed)
                    {
                        temp = Quaternion.Euler(0, transform.rotation.eulerAngles.y + angle * Time.deltaTime, 0);
                        transform.Translate(Vector3.right * Zspeed * Time.deltaTime);

                    }
                    transform.rotation = new Quaternion(temp.x, temp.y, temp.z, temp.w);
                    LetsMove();
                }
            }
        }
        else
        {
            Zspeed = DefaultSpeed;
            LetsMove();
        }
    }
    void LetsMove()
    {
        transform.Translate(0, 0, Zspeed * Time.deltaTime);
        if (Inverse)
            transform.rotation = Quaternion.Lerp(transform.rotation, defRot, H_R_Speed * Time.deltaTime);
    }
}
