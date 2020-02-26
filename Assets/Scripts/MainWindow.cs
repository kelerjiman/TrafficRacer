using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindow : GenericWindow
{
    public override void Start()
    {
        base.Start();
        PauseButton.gameObject.SetActive(false);
    }
    public override void OnPauseButton()
    {

    }
    public override void OnCloseButton()
    {
        Application.Quit();
    }
}
