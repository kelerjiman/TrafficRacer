using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //In game UI elements
    public int GM_In_gamecash = 0;
    public int GM_Total_Coins = 3000;//باید مقدار صفر شود
    public float GM_MainSpeed = 5f;
    public bool GM_Is_Accident = false;
    //به نحوه انتخاب وسیله فکر شود
    //قرار است که این گیم ابجکت در تمام بازی ست شود

    [Header("Car prefabs")]
    public GameObject[] GM_Player;
    public GameObject GM_Current_Prefab;
    [Header("Bounces Prefabs")]
    public GameObject[] GM_Bounces;
    [Header("Index Of car")]
    public int GM_PlayerCarIndex = 0;
    public Vector3 GM_DefPos = Vector3.zero;
    [SerializeField] float m_PGlobalSpeed = 5f;
    [SerializeField] int m_changeAmount = 0;

    private void Awake()
    {
        GM_Total_Coins = PlayerPrefsScript.getTotalCoin();
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Handle_ChangeCar();
        }
    }
    void Start()
    {
        Instance = this;
        Debug.Log(PlayerPrefsScript.getTotalCoin());
    }
    private void Update()
    {
        GM_Is_Accident = false;
        //todo bayad pak shavad
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return;
        GM_MainSpeed = m_PGlobalSpeed;
    }
    void Handle_Accident()
    {
        if (GM_Is_Accident)
        {

        }
    }
    public void Handle_ChangeCar()
    {
        if (Instance.GM_Current_Prefab == null)
            return;
        var temp = FindObjectsOfType<Movement>();
        if (temp.Length > 0)
        {
            foreach (var item in temp)
            {
                Destroy(item.gameObject);
            }
        }
        GM_Current_Prefab = Instantiate(GameManager.Instance.GM_Current_Prefab);
        GM_DefPos.y += 0.4f;
        GM_Current_Prefab.transform.position = GM_DefPos;
        GM_Current_Prefab.tag = "Player";
        GM_Current_Prefab.layer = LayerMask.NameToLayer("Player");
    }
    public bool purchaseItem(int price)
    {
        bool condition = false;
        if (GM_Total_Coins >= price)
        {
            GM_Total_Coins -= price;
            condition = true;
            PlayerPrefsScript.setTotalCoin(GM_Total_Coins);
            Debug.Log("purchased");
        }
        return condition;
    }
}

        //روی ساخت ماشین ها مختلف کار شود 
        // player  گیم ابجکت های مختلف باید ست شود برای این کار باید
        //GM_PlayerIndex
        //از حالت اینتجر به گیم ابجکت تغییر کند
        #region Old_Code
        /*
         public static GameManager GM;
        //In game UI elements
        public int GM_In_gamecash = 0;
        public float GM_MainSpeed = 5f;
        public bool GM_Is_Accident = false;

        به نحوه انتخاب وسیله فکر شود 
         قرار است که این گیم ابجکت در تمام بازی ست شود
         ///////////////////////////////////////////////////////////////////////////////////////

        [Header("Car prefabs")]
        public GameObject[] GM_Player;
        public GameObject GM_Current_Prefab;
        [Header("Bounces Prefabs")]
        public GameObject[] GM_Bounces;
        [Header("Index Of car")]
        public int GM_PlayerCarIndex = 0;
        public Vector3 GM_DefPos = Vector3.zero;
        [SerializeField] float m_PGlobalSpeed = 5f;
        [SerializeField] int m_changeAmount = 0;

        private void Awake()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                Handle_ChangeCar();
            }
        }
        void Start()
        {
            GM = this;

        }
        private void Update()
        {
            GM_Is_Accident = false;
            //todo bayad pak shavad
            if (SceneManager.GetActiveScene().buildIndex == 0)
                return;
            GM_MainSpeed = m_PGlobalSpeed;
        }
        void Handle_Accident()
        {
            if (GM_Is_Accident)
            {

            }
        }
        public void Handle_ChangeCar()
        {
            var temp = FindObjectsOfType<Movement>();
            if (GM.GM_Current_Prefab == null)
                return;
            if (temp.Length > 0)
            {
                foreach (var item in temp)
                {
                    Destroy(item.gameObject);
                }
            }
            GM_Current_Prefab = Instantiate(GameManager.GM.GM_Current_Prefab);
            GM_Current_Prefab.transform.position = GM_DefPos;
            GM_Current_Prefab.tag = "Player";
            GM_Current_Prefab.layer = LayerMask.NameToLayer("Player");
            */
        #endregion
