using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    class SetDefaultCar
    {
        public string DefaultCarName(CarNames _CarNames_Enum)
        {
            var temp = string.Empty;
            switch (_CarNames_Enum)
            {
                case CarNames.Ambulance:
                    temp = "Ambulance";
                    break;
                case CarNames.NormalCar:
                    temp = "Normal";
                    break;
                case CarNames.Jeep:
                    temp = "Jeep";
                    break;
                case CarNames.Bus:
                    temp = "Bus";
                    break;
                case CarNames.Van:
                    temp = "Van";
                    break;
                case CarNames.SuperCar:
                    temp = "Super";
                    break;
                case CarNames.Police:
                    temp = "Police";
                    break;
                case CarNames.Taxi:
                    temp = "Taxi";
                    break;
                case CarNames.Camper:
                    temp = "CamperVan";
                    break;
                case CarNames.Construct:
                    temp = "ConstructionTruck";
                    break;
                case CarNames.Water:
                    temp = "Water";
                    break;
                case CarNames.Crane:
                    temp = "Crane";
                    break;
                default:
                    break;
            }
            return temp;
        }
    }
    enum CarNames
    {
        NormalCar,
        Jeep,
        Bus,
        Van,
        SuperCar,
        Police,
        Taxi,
        Camper,
        Construct,
        Water,
        Crane,
        Ambulance
    }
    public static GameManager Instance;
    [SerializeField] CarNames DefaultCarNames;
    string FirstCar;

    [HideInInspector]
    public int GM_CashInGame = 0;
    public int GM_Total_Coins = 0;
    [Space(5)]
    [Header("----------------------------------------------")]
    public float GM_PlayerSpeed = 5f;
    [SerializeField] internal float inter_AISpeed = 5f;
    public int GM_Multiple = 1;
    [Space(10)]
    [Header("-----------------Car Prefab--------------------")]
    [Space(5)]
    public GameObject[] GM_Player;
    public GameObject GM_Current_Prefab;
    public Movement GM_player;
    public bool GM_Is_Accident = false;
    //Encrease Speed Properties
    [Space(10)]
    [Header("---------------Enc Speed------------------------")]
    [Space(10)]
    [SerializeField]
    internal float timer = 25;
    float m_TimerTemp = 0;
    [SerializeField] int Unit = 5;
    [SerializeField] float DefSpeed = 0;
    float StartSpeed = 0;
    [Header("----------------------------------------------")]
    Vector3 m_DefScale = Vector3.zero;
    Vector3 m_DefPos = Vector3.zero;
    private void Awake()
    {
        GM_Total_Coins = PlayerPrefsScript.getTotalCoin();
        //Debug.Log("Scene Index is : " + SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            //Debug.Log("Game manager Awake");
            Handle_ChangeCar();
        }
    }
    void Start()
    {
        RestorePurchasing();
        Instance = this;
        Handle_ChangeCar();
        m_DefScale = GM_Current_Prefab.transform.localScale;
        GM_PlayerSpeed = DefSpeed;
        StartSpeed = DefSpeed;
    }
    private void Update()
    {
        //GM_Is_Accident = false;
        //todo bayad pak shavad
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return;
        //GM_MainSpeed = m_PGlobalSpeed;
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
        {
            string TempName = PlayerPrefsScript.getCurrentCar();
            //Debug.Log("Current Car is :" + TempName);
            if (TempName != string.Empty)
            {
                foreach (var car in GM_Player)
                {
                    if (car.name == PlayerPrefsScript.getCurrentCar())
                        GM_Current_Prefab = car;
                }
            }
            else
            {
                //Debug.Log("tempName is : Empty");
                SetDefaultCar SDC = new SetDefaultCar();
                FirstCar = SDC.DefaultCarName(DefaultCarNames);
                //Debug.Log("tempName is : " + FirstCar);
                CardButton CB = new CardButton();
                CB.load_OR_open(FirstCar);
                //Debug.Log("-------------------------------------------------" +
                //"in foreach" +
                //"----------------------------------------------------");
                foreach (var car in GM_Player)
                {
                    //Debug.Log("Name of Car in GM_Player is " + car.name);
                    //Debug.Log("and First Car is : " + FirstCar);
                    //Debug.Log("----------------------------------------------------");

                    if (car.name == FirstCar)
                    {
                        GM_Current_Prefab = car;
                        //Debug.Log("GM Current Prefab Name is :" + car.name);
                    }
                }

                //Debug.Log("-------------------------------------------------" +
                //    "End foreach" +
                //    "----------------------------------------------------");
            }
            return;
        }
        var temp = FindObjectsOfType<Movement>();
        if (temp.Length > 0)
        {
            foreach (var item in temp)
            {
                Destroy(item.gameObject);
            }
        }
        GM_Current_Prefab = Instantiate(Instance.GM_Current_Prefab);
        m_DefPos.y += 0.25f;
        GM_Current_Prefab.transform.position = m_DefPos;
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
            //Debug.Log("purchased");
        }
        return condition;
    }
    public void RestorePurchasing()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Scale(Movement player, int x, bool IsPositive)
    {
        var temp = player.transform.localScale;
        if (IsPositive)
            player.transform.localScale = Vector3.Lerp(temp, temp * 2, 2 * Time.deltaTime);
        else
            player.transform.localScale = Vector3.Lerp(temp, (temp * -2), 2 * Time.deltaTime);
        StartCoroutine(ScaleTimer(player, x));
    }
    public void speed( int x, bool Positive)
    {
        if (Positive)
        {
            GM_PlayerSpeed += (int)(GM_PlayerSpeed * 10 / 100);
        }
        else
        {
            GM_PlayerSpeed -= (int)(GM_PlayerSpeed * 10 / 100);
        }
        StartCoroutine(SpeedTimer( x));
    }
    IEnumerator ScaleTimer(Movement player, int x)
    {
        yield return new WaitForSeconds(x);
        player.transform.localScale = m_DefScale;
        //Vector3.Lerp(player.transform.localScale, defScale, 2 * Time.deltaTime);
    }
    IEnumerator SpeedTimer( int x)
    {
        yield return new WaitForSeconds(x);
        Reload_Speed();
    }
    public void Reload_Speed()
    {
        DefSpeed = StartSpeed;
        GM_PlayerSpeed = DefSpeed;
    }
    public void Handle_EncSpeed()
    {
        DefSpeed += Unit;
        GM_PlayerSpeed = DefSpeed;
    }
}
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
