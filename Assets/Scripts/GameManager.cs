using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    //In game UI elements
    public int GM_In_gamecash = 0; 
    public float GM_MainSpeed = 5f;
    public bool GM_Is_Accident = false;
    /*به نحوه انتخاب وسیله فکر شود 
     قرار است که این گیم ابجکت در تمام بازی ست شود*/
    public GameObject[] GM_Player;

    [SerializeField] float m_PGlobalSpeed = 5f;
    [SerializeField] int m_changeAmount = 0;
    void Start()
    {
        GM = this;
    }
    private void Update()
    {
        GM_MainSpeed = m_PGlobalSpeed;
    }
    void Handle_Condition()
    {

    }
    void Handle_Accident()
    {
        if (GM_Is_Accident)
        {

        }
    }
}
