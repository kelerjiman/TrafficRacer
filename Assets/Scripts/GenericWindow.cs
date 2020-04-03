using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenericWindow : MonoBehaviour, IWindowGeneric
{
    public Text Coins;
    public Button CloseButton;
    public Button PauseButton;
    public GameObject PreviousWindow;
    [SerializeField] SplashScreen splash;
    public virtual void Start()
    {
        reloadSetting();
        PauseButton.gameObject.SetActive(false);
    }
    public virtual void Update()
    {

    }
    public virtual void OnAccident()
    {
        if (GameManager.Instance.GM_Is_Accident)
        {
            Debug.Log("onACCIDENT");
        }
    }
    public virtual void OnCloseButton()
    {
        PreviousWindow.SetActive(true);
        PreviousWindow.GetComponent<IWindowGeneric>().reloadSetting();
        gameObject.SetActive(false);
    }
    public virtual void OnPauseButton()
    {
        Debug.Log("On Pause Button");
        Time.timeScale = 0;
        PreviousWindow.SetActive(true);
        PreviousWindow.GetComponent<IWindowGeneric>().reloadSetting();
        gameObject.SetActive(false);
    }
    public virtual void OnNext(GameObject NextWin)
    {
        NextWin.gameObject.SetActive(true);
        NextWin.GetComponent<IWindowGeneric>().reloadSetting();
        this.gameObject.SetActive(false);
    }
    public virtual void OnNextScene(int SIndex)
    {
        SceneManager.LoadScene(SIndex);
        //داخل بازی ارور میدهد.
    }
    public virtual void reloadSetting()
    {
        Time.timeScale = 1;
        Button CloseBtn = CloseButton.GetComponent<Button>();
        Button PauseBtn = PauseButton.GetComponent<Button>();
        CloseBtn.onClick.RemoveAllListeners();
        PauseBtn.onClick.RemoveAllListeners();
        CloseBtn.onClick.AddListener(() => OnCloseButton());
        PauseBtn.onClick.AddListener(() => OnPauseButton());
        Debug.Log("this is " + gameObject.name);
        PauseBtn.gameObject.SetActive(false);
        splash = GetComponentInChildren<SplashScreen>();
        if (splash != null)
        {
            //splash.FadeInOut(true);
            splash.FadeInOut(false);
            Debug.Log(splash.name);
        }
    }
    //listener 
}
