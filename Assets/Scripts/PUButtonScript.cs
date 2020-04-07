using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUButtonScript : MonoBehaviour
{
    [SerializeField] string PUName;
    [SerializeField] Text PriceText;
    [SerializeField] int StarterPrice = 300;
    [SerializeField] AudioSource source;
    private int currentPrice = 0;
    int currentLevel = 0;
    [SerializeField] int MaxLevel = 4;
    private void Start()
    {
        //PlayerPrefs.DeleteKey(PUName);
        currentLevel = PlayerPrefsScript.getPowerUpLevel(PUName);
        if (currentLevel == 0)
        {
            currentLevel = 1;
            PlayerPrefsScript.setPowerUpLevel(PUName, currentLevel);
        }
        MaxUpgardeHandle(); Debug.Log("Start of PUButtonScript");
    }
    public void OnButtonClick()
    {
        Debug.Log("OnButtonClick of PUButtonScript");
        currentLevel++;
        PlayerPrefsScript.setPowerUpLevel(PUName, currentLevel);
        bool condition = GameManager.Instance.purchaseItem(currentPrice);
        if (condition)
            MaxUpgardeHandle();
        else
            source.Play();
        GetComponentInParent<GenericWindow>().reloadSetting();
    }
    private void MaxUpgardeHandle()
    {
        if (currentLevel == MaxLevel)
        {
            gameObject.GetComponent<Button>().interactable = false;
            PriceText.text = "MAX";

        }
        else
        {
            currentPrice = StarterPrice * currentLevel;
            PriceText.text = currentPrice.ToString();
        }
    }
    //upgrade ha ro dorosht kon
    //vaghti ke coin be hade nesabe kharid miresad dar scene 2 
    // va ba ad az bazgast be scene 1 button ha taghre state midahand 
    // onbutton click ajra mishavad in moshkel ra hal kon.

}
