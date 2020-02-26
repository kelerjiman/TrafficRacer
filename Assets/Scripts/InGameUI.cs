using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    //[Header("IN Game Score Script")]
    //[SerializeField]
    //InGameCash Score_InGame;
    //[Header("UI TEXTS")]
    //[SerializeField]
    //Text T_InGameCash;
    //[SerializeField] Text T_Time;
    //[SerializeField] Text T_MainSpeed;
    //[SerializeField] Text T_CurrentSpeed;
    //[SerializeField] Text T_Messions;

    //private float m_inGamecash;
    //private float m_time;
    //private float m_mainSpeed;
    //private float m_currentSpeed;
    //Movement player;
    private void Start()
    {
        //player = FindObjectOfType<Movement>();
        //Score_InGame = FindObjectOfType<InGameCash>();
    }
    private void Update()
    {
        //Handle_MainSpeed();
        //Handle_CurrentSpeed();
        //Handle_Time();
        //Handle_InGameCash();
    }
    //void Handle_MainSpeed()
    //{
    //    T_MainSpeed.text = (GameManager.GM.GM_MainSpeed * 2).ToString();
    //}
    //void Handle_CurrentSpeed()
    //{
    //    m_currentSpeed = player.GetComponent<Rigidbody>().velocity.z;
    //    T_CurrentSpeed.text = Mathf.Round(player.GetComponent<Rigidbody>().velocity.z * 2).ToString();
    //}
    //void Handle_Time()
    //{
    //    T_Time.text = Mathf.Round(Score_InGame.Timer).ToString();
    //}
    //void Handle_InGameCash()
    //{
    //    //m_inGamecash = Score_InGame.Score_InGame;
    //    T_InGameCash.text = Score_InGame.Score_InGame.ToString();
    //}
}
