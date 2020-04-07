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
        OnNext(PreviousWindow);
    }
    public virtual void OnPauseButton()
    {
        Debug.Log("On Pause Button");
        Time.timeScale = 0;
        OnNext(PreviousWindow);
    }
    public virtual void OnNext(GameObject NextWin)
    {
        StartCoroutine(SW_Window(NextWin));
    }
    IEnumerator SW_Window(GameObject NextWin = null, int i = -1)
    {
        if (splash != null)
            splash.FadeInOut(true);
        yield return new WaitForSeconds(0.70f);
        if (NextWin != null)
        {
            NextWin.GetComponent<IWindowGeneric>().reloadSetting();
            NextWin.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
            if (i > -1)
            SceneManager.LoadScene(i);
    }
    public virtual void OnNextScene(int SIndex)
    {
        if (GameManager.Instance.player != null)
            GameManager.Instance.player.gameObject.SetActive(true);
        StartCoroutine(SW_Window(null, SIndex));
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
        if (Coins != null)
            Coins.text = GameManager.Instance.GM_Total_Coins.ToString();
    }
}
