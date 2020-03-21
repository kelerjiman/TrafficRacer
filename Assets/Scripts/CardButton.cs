using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class CardButton : MonoBehaviour
{
    public Image LockImage;
    public bool Is_Locked = true;
    public Image CarIcon;
    public Image CoinRateBar;
    public Image MultipleRateBar;
    public string CarName;
    public GameObject Prefab;
    public int price = 0;
    private Button m_btn;
    private AudioSource source;
    [SerializeField] private SelectCarWindow m_btnParent;
    public PurchaseCarWindow PCarWindow;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        load_OR_open();
        m_btnParent = FindObjectOfType<SelectCarWindow>();
        transform.localScale = new Vector3(1, 1, 1);
        m_btn = this.GetComponent<Button>();
        m_btn.onClick.AddListener(OnClickEvent);

    }
    private void OnEnable()
    {
        load_OR_open();
    }

    public void SetInfo(SO_CarCard item)
    {
        CarIcon.sprite = item.GetCarIcon();
        CoinRateBar.fillAmount = item.GetCoinRate();
        MultipleRateBar.fillAmount = item.GetScoreRate();
        CarName = item.GetCarName();
        Prefab = item.GetPrefab();
        price = item.GetPrice();

    }
    void OnClickEvent()
    {
        tempInfo();
        if (Is_Locked)
        {
            Debug.Log("this vehicle is locked !");
            return;
        }
        GameManager.Instance.GM_Current_Prefab = Prefab;
        PlayerPrefsScript.setCurrentCar(Prefab.name);
        m_btnParent.OnCloseButton();
    }
    public void load_OR_open(string _CarName = null)
    {
        //Debug.Log("Load_OR_open Method");
        if (_CarName == null)
        {
            //Debug.Log("CarName is :" + CarName);
            if (PlayerPrefs.HasKey(CarName))
            {
                //Debug.Log("PlayerPrefs.HasKey(CarName) is :"+ PlayerPrefs.HasKey(CarName));
                int param = PlayerPrefsScript.getCarUnlock(CarName);
                //Debug.Log("param is :" + param);
                Is_Locked = (param == 1) ? false : true;
            }
            else
                Is_Locked = true;
            //Debug.Log("IsLock is :" + Is_Locked);
            LockImage.gameObject.SetActive(Is_Locked);
            //Debug.Log("---------------------------------------------------------------------");
        }
        else
        {
            //Debug.Log("Load_OR_open Method : _CarName is : "+ _CarName);
            PlayerPrefsScript.setCarUnlock(_CarName, false);
        }
    }
    public void saveData()
    {
        PlayerPrefsScript.setCarUnlock(CarName, Is_Locked);
        load_OR_open();
    }
    public void Unlocking()
    {
        PCarWindow.gameObject.SetActive(true);
        PCarWindow.GetComponent<IWindowGeneric>().reloadSetting();
        PCarWindow.SetInfo(price);
        PCarWindow.cardButton = gameObject.GetComponent<CardButton>();
    }
    void tempInfo()
    {
        Debug.Log(CarName + " " + PlayerPrefsScript.getCarUnlock(CarName));
    }
}
