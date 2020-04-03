using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseCarWindow : GenericWindow
{
    [SerializeField] GameObject alarmText;
    public CardButton cardButton;
    [SerializeField] Text Price_text;
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
        if (!cardButton.Is_Locked)
            gameObject.SetActive(false);
    }
    public void SetInfo(int price)
    {
        alarmText.SetActive(false);
        Price_text.text = price.ToString();
    }
    public void purchasing()
    {
        if (cardButton.Is_Locked)
        {
            bool temp = GameManager.Instance.purchaseItem(cardButton.price);
            cardButton.Is_Locked = !temp;
            cardButton.saveData();
            if (temp)
                OnNext(PreviousWindow);
            alarmText.SetActive(cardButton.Is_Locked);
        }
    }
    public override void OnNext(GameObject NextWin)
    {
        NextWin.GetComponent<IWindowGeneric>().reloadSetting();
        NextWin.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
