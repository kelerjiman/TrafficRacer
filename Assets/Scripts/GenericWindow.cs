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
    public virtual void Start()
    {
        PauseButton.gameObject.SetActive(false);
        Button CloseBtn = CloseButton.GetComponent<Button>();
        Button PauseBtn = PauseButton.GetComponent<Button>();
        //CloseBtn.onClick.AddListener(OnCloseButton);
        CloseBtn.onClick.RemoveAllListeners();
        PauseBtn.onClick.RemoveAllListeners();
        CloseBtn.onClick.AddListener(() => OnCloseButton());
        PauseBtn.onClick.AddListener(() => OnPauseButton());
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
        gameObject.SetActive(false);
        PreviousWindow.GetComponent<IWindowGeneric>().reloadSetting();
    }
    public virtual void OnPauseButton()
    {
        Debug.Log("On Pause Button");
        Time.timeScale = 0;
        PreviousWindow.SetActive(true);
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
    }
    public virtual void reloadSetting()
    {
        Button CloseBtn = CloseButton.GetComponent<Button>();
        Button PauseBtn = PauseButton.GetComponent<Button>();
        //CloseBtn.onClick.AddListener(OnCloseButton);
        //PauseBtn.onClick.AddListener(OnPauseButton);
        CloseBtn.onClick.AddListener(() => OnCloseButton());
        PauseBtn.onClick.AddListener(() => OnPauseButton());
    }
    //listener 
}
