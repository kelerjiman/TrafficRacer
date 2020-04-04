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
    public SplashScreen Splash;
    [SerializeField] CarNames DefaultCarNames;
    string FirstCar;
    //In game UI elements
    public int GM_In_gamecash = 0;
    public int GM_Total_Coins = 3000;//باید مقدار صفر شود
    public float GM_MainSpeed = 5f;
    public bool GM_Is_Accident = false;
    public int GM_Multiple = 1;
    //به نحوه انتخاب وسیله فکر شود
    //قرار است که این گیم ابجکت در تمام بازی ست شود

    [Header("Car prefabs")]
    public GameObject[] GM_Player;
    public GameObject GM_Current_Prefab;
    public Movement player;
    [Header("Bounces Prefabs")]
    public GameObject[] GM_Bounces;
    [Header("Index Of car")]
    public int GM_PlayerCarIndex = 0;
    public Vector3 GM_DefPos = Vector3.zero;
    [SerializeField] float m_PGlobalSpeed = 5f;
    [SerializeField] int m_changeAmount = 0;
    float m_defSpeed = 0;
    Vector3 defScale = Vector3.zero;

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
        Instance = this;
        Handle_ChangeCar();
        defScale = GM_Current_Prefab.transform.localScale;
        m_defSpeed = GM_MainSpeed;
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
        if (GameManager.Instance.GM_Current_Prefab == null)
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
    public void speed(Movement player, int x, bool Positive)
    {
        if (Positive)
        {
            GM_MainSpeed += (int)(GM_MainSpeed * 10 / 100);
        }
        else
        {
            GM_MainSpeed -= (int)(GM_MainSpeed * 10 / 100);
        }
        StartCoroutine(SpeedTimer(player, x));
    }
    IEnumerator ScaleTimer(Movement player, int x)
    {
        yield return new WaitForSeconds(x);
        player.transform.localScale = defScale;
            //Vector3.Lerp(player.transform.localScale, defScale, 2 * Time.deltaTime);
    }
    IEnumerator SpeedTimer(Movement player, int x)
    {
        yield return new WaitForSeconds(x);
        GM_MainSpeed = m_defSpeed;
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
