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
    }
    void MoveHandle()
    {
        transform.Translate(0, 0, GlobalSpeed * Time.deltaTime);
    }
    public void OnEnterHandle()
    {
        Debug.Log("On Enter Handle");
    }
    public void OnStayHandle()
    {
        Debug.Log("On Stay Handle");
    }
    public void OnExitHandle()
    {
        Debug.Log("On Exit Handle");
    }
}
