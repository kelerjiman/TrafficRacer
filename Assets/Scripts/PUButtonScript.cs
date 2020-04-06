using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUButtonScript : MonoBehaviour
{
    [SerializeField] string Name;
    [SerializeField] Text PriceText;
    private int currentPrice = 300;
    [SerializeField] bool MaxUpgrade = false;
    private void Start()
    {
        if (MaxUpgrade)
        {
            PriceText.text = "MAX";
            GetComponent<Button>().interactable = false;
        }
        else
            PriceText.text = currentPrice.ToString();
    }
    public void OnButtonClick()
    {
        Debug.Log("Upgradeof " + name + " was completed !");
        currentPrice += 300;
        PriceText.text = (currentPrice).ToString();
    }
}
