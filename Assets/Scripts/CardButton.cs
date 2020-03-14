using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    [SerializeField] private SelectCarWindow m_btnParent;
    public PurchaseCarWindow PCarWindow;

    private void Start()
    {
        loadData();
        m_btnParent = FindObjectOfType<SelectCarWindow>();
        transform.localScale = new Vector3(1, 1, 1);
        m_btn = this.GetComponent<Button>();
        m_btn.onClick.AddListener(OnClickEvent);

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
        m_btnParent.OnCloseButton();
    }
    public void loadData()
    {
        if (PlayerPrefs.HasKey(CarName))
        {
            int param = PlayerPrefsScript.getCarUnlock(CarName);
            Is_Locked = (param == 1) ? false : true;
        }
        else
            Is_Locked = true;
        LockImage.gameObject.SetActive(Is_Locked);
    }
    public void saveData()
    {
        PlayerPrefsScript.setCarUnlock(CarName,Is_Locked);
        loadData();
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
