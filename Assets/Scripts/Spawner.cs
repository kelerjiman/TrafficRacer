using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float ChangeLine_Xpos = 0;// مقدار مسافتی که در زمان تعویض لاین باید جا به جا شود
    public float SpawnX = 0;//مکان ساخته شدن از نظر مدار ایکس
    public bool reverse = false;//لاین مخالف را تعیین می کند 
    public bool Is_Ins_Time = false;//هنوز استفاده نشده است (قرار است که ساختن را کنترل کند)ی
    public Vector2 Respawn_Dly = new Vector2(0, 5);//فاصله بین ساخته شدن اتوموبیل ها در واحد زمان

    [SerializeField] List<GameObject> PrefabList;
    [SerializeField] int VehicleCount = 10;//تعداد ماشین هایی که هم
                                           //زمان می توانند در لاین قرار بگیرند

    [SerializeField] int Ref_Size = 4;//فاصله بین ماشین ها را تعیین میکند

    [SerializeField] float Spawn_Z = 0;//میزان فاصله بین بازیکن و جایی که ماشین ها 
    [SerializeField] float m_zpadding;
    //ساخته می شوند را تعیین میکند
    private Movement m_Player;
    private GameObject m_currentOBJ;
    private int m_NumberOfChildren;
    private float m_Timer = 0f;
    private float m_Timer_temp = 0;

    private void Awake()
    {
        m_currentOBJ = PrefabList[UnityEngine.Random.Range(0, PrefabList.Count)];
        m_Timer = UnityEngine.Random.Range(Respawn_Dly.x, Respawn_Dly.y);
    }
    private void Start()
    {
        m_Player = FindObjectOfType<Movement>();

    }
    private void Update()
    {
        if (GameManager.Instance.GM_Is_Accident)
            return;
        m_NumberOfChildren = gameObject.GetComponentsInChildren<cars>().Length;
        if (m_NumberOfChildren < VehicleCount)
            Handle_RespawnTime();
    }
    private void Handle_RespawnTime()
    {
        if (m_Timer_temp < m_Timer)
        {
            m_Timer_temp += Time.deltaTime;
            return;
        }
        Is_Ins_Time = true;
        m_Timer_temp = m_Timer;
        Handle_Respawn(m_currentOBJ);
        m_Timer_temp = 0;
        m_Timer = UnityEngine.Random.Range(Respawn_Dly.x, Respawn_Dly.y);
    }
    private void Handle_Respawn(GameObject vehicle)
    {
        if (!Is_Ins_Time)
            return;
        if (m_NumberOfChildren < VehicleCount &&
            m_Player.transform.position.z > (Spawn_Z - VehicleCount * Ref_Size))
        {
            var _vehicle = Instantiate(vehicle) as GameObject;
            _vehicle.layer = LayerMask.NameToLayer("Cars");
            _vehicle.tag = "Obs";
            _vehicle.transform.parent = transform;
            Handle_SpawnZ(_vehicle);
            Is_Ins_Time = false;
            Vehicle_Picker();
        }
    }

    private void Handle_SpawnZ(GameObject Obj)
    {
        var temp = Vector3.zero;
        Spawn_Z = m_Player.transform.position.z + m_zpadding;
        temp.z = Spawn_Z;
        Obj.transform.position = temp;
        Handle_SpawnX(Obj);
    }
    private void Handle_SpawnX(GameObject Obj)
    {
        Vector3 temp = Obj.transform.position;
        temp.x += SpawnX;
        Obj.transform.position = temp;
        Handle_Rotation(Obj);
    }


    private void Handle_Rotation(GameObject Obj)
    {
        if (reverse)
        {
            Obj.transform.rotation = Quaternion.Euler(0, 180, 0);
            Obj.GetComponent<cars>().MainSpeed *= -1;
        }
    }
    private void Vehicle_Picker()
    {
        m_currentOBJ = PrefabList[UnityEngine.Random.Range(0, PrefabList.Count)];
    }
    
}
