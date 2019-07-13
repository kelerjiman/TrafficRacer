using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SignBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public int SIndex = 0;
    [HideInInspector]
    public string[] SType = { "information", "Laws" };

    //////////////////////////////////////////////////////////
    public float GlobalSpeed = 0f;
    /// <summary>
    /// ////////////////////////////////////////////////
    /// </summary>

    [SerializeField] GameObject Holder;
    [SerializeField] List<GameObject> SignText;
    public List<string> messages;
    private void Start()
    {
        GlobalSpeed = GameManager.GlobalSpeed;
        ReloadInfo();
    }
    private void Update()
    {
        MoveHandle();
    }

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

    void MoveHandle()
    {
        transform.Translate(0, 0, GlobalSpeed * Time.deltaTime);
    }
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
}
