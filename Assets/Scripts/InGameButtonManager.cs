using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameButtonManager : MonoBehaviour
{
    [SerializeField] CanvasRenderer PausePanel;
    [SerializeField] CanvasRenderer LoosePanel;
    [SerializeField] CanvasRenderer WinPanel;
    [SerializeField] string activeWindow;
    [SerializeField] GameObject[] WindowList;
    [SerializeField]
    Movement player;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
    }
    private void Update()
    {
        if (!player)
            player = FindObjectOfType<Movement>();
    }
    //متد برای دکمه های یو آی
    public void Event_Dir_Down(int x)
    {
        Debug.Log(player);
        player.X_Input = x;
    }
    public void Event_Acc_Down(int x)
    {
        player.Z_Input = x;
    }
    public void Event_Up(bool dir)
    {
        Debug.Log(player);
        if (dir)
            player.X_Input = 0;
        else
            player.Z_Input = 0;
    }
    public void Pause_Button()
    {
        foreach (var win in WindowList)
        {
            if (win.activeSelf)
                break;

        }
    }
    public void Exit_Button()
    {
        Application.Quit();
    }
    public void Reload_Button()
    {
        SceneManager.LoadScene(0);
        BackToDefault();
    }
    public void OnNext(GameObject NextWin)
    {
        Debug.Log("OnNext");
        if (NextWin.name != activeWindow)
            foreach (var win in WindowList)
            {
                if (win.name == NextWin.name)
                    win.gameObject.SetActive(true);
                else
                    win.gameObject.SetActive(false);
            }
        activeWindow = NextWin.name;
        //if (activeWindow == "RunTimeWindow")
        //    SceneManager.LoadScene(1);
        //if (activeWindow == "MainWindow")
        //    SceneManager.LoadScene(0);
    }
    public void OnNextScene(int SIndex)
    {
        if (SceneManager.GetActiveScene().buildIndex != SIndex)
            SceneManager.LoadScene(SIndex);
    }
    public void Main_Menu_Button()
    {

    }
    public void Sound_Pitch(int x)
    {
        Debug.Log("player.source.pitch");
    }
    private void BackToDefault()
    {
        LoosePanel.gameObject.SetActive(false);
        WinPanel.gameObject.SetActive(false);
        PausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
