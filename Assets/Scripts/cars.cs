using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class cars : MonoBehaviour
{// Start is called before the first frame update
    public float Zspeed = -2f, DefaultSpeed;
    [SerializeField]
    [Range(0, 1)]
    float H_R_Speed = 1f;
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
    float angle = 30f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ground" && collision.gameObject.tag != "Player"&& collision.gameObject.layer!=LayerMask.NameToLayer("Cars"))
            Destroy(gameObject);
    }
    private void Awake()
    {
        H_R_Speed = 1f;
        angle = 30f;
        gameObject.layer = LayerMask.NameToLayer("Cars");
    }
    void Start()
    {

        tag = "Obs";
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
            front = lights.FrontObject;
            if (front.gameObject != null && front.gameObject.activeInHierarchy)
            {
                if (front.layer == LayerMask.NameToLayer("Cars"))
                    Zspeed = front.GetComponent<cars>().Zspeed;
            }
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
                    transform.rotation = Quaternion.Lerp(transform.rotation, temp, H_R_Speed);
                }
            }
            else
            {

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
        //if (Inverse)
        transform.rotation = Quaternion.Lerp(transform.rotation, defRot, H_R_Speed * Time.deltaTime);
    }
}
