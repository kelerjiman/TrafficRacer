using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SignBehavior : MonoBehaviour
{
    /// <summary>
    /// 1- vars for sign Editor
    /// 2- vars for global system recived from gameManager
    /// 3- vars and properties for the this sign
    ///     3-1 holder :
    ///                     the gameObject that have box collider for using such as flags
    ///     3-2 signTexts :
    ///                     list of gameObject that have TextMeshPro for get Informations to Player
    ///     3-3 message :
    ///                     list of message that recived from gameManager for importing to the signText(3-2)
    /// </summary>

    /*section 1*/
    [HideInInspector]
    public int SIndex = 0;
    [HideInInspector]
    public string[] SType = { "information", "Laws" };
    /*section 2*/
    public float GlobalSpeed = 0f;
    /*section 3*/
    [SerializeField] GameObject SignImage;
    [SerializeField] GameObject Holder;
    [SerializeField] List<GameObject> SignText;
    public List<string> messages;
    private void Start()
    {
        GlobalSpeed = GameManager.GM.GM_MainSpeed;
        ReloadInfo();
    }
    private void Update()
    {
        MoveHandle();
    }

    #region Collisions Handler
    /// <summary>
    /// Collisions Handler
    /// </summary>
    public void OnEnterHandle()
    {
        //define the message and starting 
    }
    public void OnStayHandle()
    {
        //define timers and etc
    }
    public void OnExitHandle()
    {
        //stop functions and caculate result
    }
    #endregion
    /// <summary>
    /// Movement Handler
    /// </summary>
    void MoveHandle()
    {
        transform.Translate(0, 0, GlobalSpeed * Time.deltaTime);
    }
    /// <summary>
    /// Reloading Info
    /// </summary>
    private void ReloadInfo()
    {
        for (int i = 0; i < SignText.Count; i++)
        {
            if (messages[i] != "")
                SignText[i].transform.GetChild(0).GetComponent<TextMeshPro>().text = messages[i];
            else
                SignText[i].transform.GetChild(0).GetComponent<TextMeshPro>().text = "";
        }
    }
}
