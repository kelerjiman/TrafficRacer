using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenericWindow : MonoBehaviour
{

    public Movement player;
    public Button CloseButton;
    public Button PauseButton;
    public GameObject PreviousWindow;
    public virtual void Start()
    {
        player = FindObjectOfType<Movement>();
        Button CloseBtn = CloseButton.GetComponent<Button>();
        Button PauseBtn = PauseButton.GetComponent<Button>();
        CloseBtn.onClick.AddListener(OnCloseButton);
        PauseBtn.onClick.AddListener(OnPauseButton);
    }
    public virtual void Update()
    {

    }
    public virtual void OnAccident()
    {
        if (GameManager.GM.GM_Is_Accident)
        {
            Debug.Log("onACCIDENT");
        }
    }
    public virtual void OnCloseButton()
    {
        Debug.Log("OnClose Button");
        PreviousWindow.SetActive(true);
        gameObject.SetActive(false);

    }
    public virtual void OnPauseButton()
    {
        Debug.Log("On Pause Button");
        PreviousWindow.SetActive(true);
        gameObject.SetActive(false);
    }
    public virtual void OnNext(GameObject NextWin)
    {
        NextWin.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public virtual void OnNextScene(int SIndex)
    {
            SceneManager.LoadScene(SIndex);
    }
    //listener 

}
