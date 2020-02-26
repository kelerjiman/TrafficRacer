using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public Image CarIcon;
    public Image CoinRateBar;
    public Image MultipleRateBar;
    public string CarName;
    public GameObject Prefab;
    private Button m_btn;
    [SerializeField]private SelectCarWindow m_btnParent;


    private void Start()
    {
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
    }
    void OnClickEvent()
    {
        FindObjectOfType<GameManager>().GM_Current_Prefab = Prefab;
        Debug.Log(Prefab.name);
        m_btnParent.OnCloseButton();
    }
}
