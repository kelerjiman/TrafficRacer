﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Movement : MonoBehaviour
{
    [SerializeField] VehichleProp VProps;//خصوصیات یک وسیله
    [SerializeField] float MainSpeed = 0;//سرعت اصلی بازی که از طرف هسته اصلی تنظیم می شود
    public float Z_Input = 0;//برای تشخیص گاز و ترمز استفاده می شود 
    [SerializeField]
    public float X_Input = 0;// برای تشخیص حرکت به راست و چپ استفاده می شود
    Rigidbody rig;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ground")
        {
            GameManager.GM.GM_Is_Accident = true;
            MainSpeed = 0;
            rig.velocity = Vector3.zero;
        }
    }
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        rig.mass = VProps.Get_Mass();
    }
    private void Start()
    {
        Speed_Norm();
    }
    private void Update()
    {
        if (GameManager.GM.GM_Is_Accident)
            return;
        MainSpeed = GameManager.GM.GM_MainSpeed;
        Handle_Speed();
        Handle_X_Move();
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
        if (rig.velocity.z < GameManager.GM.GM_MainSpeed * 2)
            rig.velocity += Vector3.forward * VProps.Get_Nitro() * Time.deltaTime;
    }
    //متد تنظیم کننده فرایند ترمز کردن
    public void Speed_Dec()
    {
        /*حداقل و حداکثر سرعت را مشخص و با ترمز و گاز بین این دو تغییر ایجاد کند.*/
        Vector3 temp = Vector3.forward * GameManager.GM.GM_MainSpeed;

        rig.velocity = Vector3.Lerp(rig.velocity, temp, VProps.Get_Breaking()/* * Time.deltaTime*/);
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
        rig.velocity += Vector3.right * X_Input * VProps.Get_HandlingRate();
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

