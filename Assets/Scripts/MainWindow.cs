using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindow : GenericWindow
{
    public override void Start()
    {
        base.Start();
        Debug.Log("On main window Start ");
    }
    public override void OnCloseButton()
    {
        Application.Quit();
    }
}
