using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunTimeWindow : GenericWindow
{
    [Header("IN Game Score Script")]
    [SerializeField]
    InGameCash Score_InGame;
    [Header("UI TEXTS")]
    [SerializeField]
    Text T_InGameCash;
    [SerializeField] Text T_Time;
    [SerializeField] Text T_MainSpeed;
    [SerializeField] Text T_CurrentSpeed;
    [SerializeField] Text T_Messions;

    [SerializeField] Movement player;
    private float m_inGamecash;
    private float m_time;
    private float m_mainSpeed;
    private float m_currentSpeed;
    [Header("Loose Panel")]
    [SerializeField]
    GameObject loosePanel;
    GameObject winPanel;

    public override void Start()
    {
        Score_InGame = FindObjectOfType<InGameCash>();
        CloseButton.gameObject.SetActive(false);
        base.Start();
        player = FindObjectOfType<Movement>();
    }
    public override void Update()
    {
        PauseButton.gameObject.SetActive(true);
        Time.timeScale = 1;
        OnAccident();
        base.Update();
        if (this.gameObject.activeSelf == true && player != null)
        {
            CloseButton.gameObject.SetActive(false);
            Handle_MainSpeed();
            Handle_CurrentSpeed();
            Handle_Time();
            Handle_InGameCash();
        }
    }


    void Handle_MainSpeed()
    {
        T_MainSpeed.text = (GameManager.Instance.GM_MainSpeed * 2).ToString();
    }
    void Handle_CurrentSpeed()
    {

        m_currentSpeed = player.GetComponent<Rigidbody>().velocity.z;
        T_CurrentSpeed.text = Mathf.Round(player.GetComponent<Rigidbody>().velocity.z * 2).ToString();
    }
    void Handle_Time()
    {
        //T_Time.text = Mathf.Round(Score_InGame.Timer).ToString();
    }
    void Handle_InGameCash()
    {
        //m_inGamecash = Score_InGame.Score_InGame;
        //T_InGameCash.text = Score_InGame.Score_InGame.ToString();
    }
    public override void OnAccident()
    {
        if (GameManager.Instance.GM_Is_Accident)
        {
            loosePanel.SetActive(true);
            this.gameObject.SetActive(false);

        }

    }
    public override void OnPauseButton()
    {
        gameObject.SetActive(false);
        PreviousWindow.SetActive(true);
        PreviousWindow.GetComponent<IWindowGeneric>().reloadSetting();
        base.OnPauseButton();
    }
    public override void reloadSetting()
    {
        base.reloadSetting();
        player.gameObject.SetActive(true);
    }
}
