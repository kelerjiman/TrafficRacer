using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 force;
    public VehichleProp VProps;//خصوصیات یک وسیله
    [SerializeField] float MainSpeed = 0;//سرعت اصلی بازی که از طرف هسته اصلی تنظیم می شود
    public float Z_Input = 0;//برای تشخیص گاز و ترمز استفاده می شود 
    public float X_Input = 0;// برای تشخیص حرکت به راست و چپ استفاده می شود
    Rigidbody rig;
    [Header("health section")]
    [Range(0, 5)]
    public int health = 1;

    public AudioSource source;
    float DefPitch;
    private AudioSource BreakSource;
    public void DamageCal(int damage)
    {
        health -= damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cars"))
        {
            health--;
            BreakSource.PlayOneShot(BreakSource.clip);
            FindObjectOfType<HeartManager>().OnOffHandle();
            if (health <= 0)
            {
                GameManager.Instance.GM_Is_Accident = true;
                ScoreManager.Instance.timeToCount = true;
            }
        }
    }
    private void Awake()
    {
        BreakSource = gameObject.AddComponent<AudioSource>();
        rig = GetComponent<Rigidbody>();
        if (VProps != null)
        {
            health = VProps.Get_Health();
            rig.mass = VProps.Get_Mass();
        }
        else
            rig.mass = 500;
    }
    private void Start()
    {
        source = GetComponent<AudioSource>();
        DefPitch = source.pitch;
        AudioManager.Instance.SetData(ref BreakSource, "Accident");
        AudioManager.Instance.SetData(ref source, GameManager.Instance.GM_Current_Prefab.name);
        source.Play();
        Speed_Norm();
    }
    private void Update()
    {
        if (GameManager.Instance.GM_Is_Accident)
        {
            source.pitch = 0;
            return;
        }
        source.pitch = (rig.velocity.z * 2) / (GameManager.Instance.GM_PlayerSpeed * 2);
        MainSpeed = GameManager.Instance.GM_PlayerSpeed;
        Handle_Speed();
        Handle_X_Move();
        ScoreManager.Instance.TotalDistance += ((int)transform.position.z - ScoreManager.Instance.TotalDistance);
    }
    //متد نشخیص جهت در محور ایکس ها
    void Condition_Dir()
    {
        X_Input = Input.GetAxisRaw("Horizontal");
    }

    //متد تشخیص گاز و ترمز
    void Condition_Gear()
    {
        Z_Input = Input.GetAxisRaw("Vertical");
    }
    //متد تنظیم کننده سرعت وسیله
    void Handle_Speed()
    {
        if (Z_Input != 0)
            if (Z_Input < 0)
                Speed_Dec();
            else
                Speed_Enc();
        Speed_Norm();
        Handle_Speed_Anim();
    }
    //متد تنظیم کننده سرعت نرمال
    void Speed_Norm()
    {
        if (rig.velocity.z >= MainSpeed)
            return;
        var temp = rig.velocity;
        if (temp.z != MainSpeed)
        {
            temp.z = MainSpeed;
        }
        rig.velocity = Vector3.Lerp(rig.velocity, temp, Time.deltaTime);
    }
    //متد تنظیم کننده فرایند گاز دادن
    public void Speed_Enc()
    {
        if (rig.velocity.z >= GameManager.Instance.GM_PlayerSpeed * 2)
            return;
        Vector3 temp = Vector3.forward * GameManager.Instance.GM_PlayerSpeed * 2;
        rig.velocity = Vector3.Lerp(rig.velocity, temp, VProps.Get_Nitro() * Time.deltaTime);
        //Debug.Log("================================================================================");
        //Debug.Log("=                                                                              =");
        //Debug.Log("=                                                                              =");
        //Debug.Log("            temp is : " + temp);
        //Debug.Log("=           rig.velocity : " + rig.velocity);
        //Debug.Log("=                                                                              =");
        //Debug.Log("================================================================================");

    }
    //متد تنظیم کننده فرایند ترمز کردن
    public void Speed_Dec()
    {
        /*حداقل و حداکثر سرعت را مشخص و با ترمز و گاز بین این دو تغییر ایجاد کند.*/
        Vector3 temp = Vector3.forward * GameManager.Instance.GM_PlayerSpeed;
        rig.velocity = Vector3.Lerp(rig.velocity, temp, VProps.Get_Breaking() * Time.deltaTime);
    }
    //متد تنظیم کننده انیمیشن برای فرایند ترمز و گاز
    void Handle_Speed_Anim()
    {

        var temp = transform.rotation;
        temp = Quaternion.Euler(-3 * Z_Input, temp.eulerAngles.y, temp.eulerAngles.z);
        if (Z_Input != 0)
        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, temp, VProps.Get_Handling_Anim_Rate());
        }
        else
        {
            temp = Quaternion.Euler(0, temp.eulerAngles.y, temp.eulerAngles.z);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, temp, VProps.Get_Handling_Anim_Rate());
        }
    }
    //متد تنظیم کننده حرکت در مدار ایکس
    void Handle_X_Move()
    {
        rig.velocity += Vector3.right * X_Input * VProps.Get_HandlingRate() * Time.deltaTime;
        if (X_Input == 0)
            rig.velocity = new Vector3(0, rig.velocity.y, rig.velocity.z);
        Handle_X_Anim();
    }
    //متد تنظیم کننده انیمیشن برای حرکت در محور ایکس
    void Handle_X_Anim()
    {
        var temp = transform.rotation;
        temp = Quaternion.Euler(temp.eulerAngles.x, 5 * X_Input, 3 * X_Input);
        if (X_Input != 0)
        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, temp, VProps.Get_Handling_Anim_Rate());
        }
        else
        {
            temp = Quaternion.Euler(temp.eulerAngles.x, 0, 0);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, temp, VProps.Get_Handling_Anim_Rate());
        }

    }
}

