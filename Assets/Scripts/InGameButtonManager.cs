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
    [SerializeField]
    Movement player;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
    }
    private void Update()
    {
        if(!player)
            player = FindObjectOfType<Movement>();
        if (GameManager.GM.GM_Is_Accident && !LoosePanel.gameObject.activeSelf)
            LoosePanel.gameObject.SetActive(true);

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
    public void Pause_Button(Button button)
    {
        if (GameManager.GM.GM_Is_Accident)
        {
            return;
        }
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            PausePanel.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PausePanel.gameObject.SetActive(false);
        }
    }
    public void Exit_Button()
    {
        Application.Quit();
    }
    public void Reload_Button()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        BackToDefault();
    }
    public void Main_Menu_Button()
    {

    }
    private void BackToDefault()
    {
        LoosePanel.gameObject.SetActive(false);
        WinPanel.gameObject.SetActive(false);
        PausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
