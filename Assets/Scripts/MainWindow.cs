using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindow : GenericWindow
{
    public override void Start()
    {
        base.Start();
        splash.SetActive(true);
        PauseButton.gameObject.SetActive(false);
    }
    public override void OnPauseButton()
    {

    }
    public override void OnCloseButton()
    {
        //روی مشکل دکمه خروج کار شود 
        // در تمام پنجره ها وقتی دکمه خروج زده می شود برنامه بسته می شود.
        Debug.Log("main menu");
    }
}
