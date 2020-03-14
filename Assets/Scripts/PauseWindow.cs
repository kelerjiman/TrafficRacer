using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : GenericWindow
{
    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
        base.Update();
        if (!PauseButton.gameObject.activeSelf)
            PauseButton.gameObject.SetActive(false);
    }
    public override void OnCloseButton()
    {
        SceneManager.LoadScene(0);
    }
    public override void OnNextScene(int SIndex)
    {
        SceneManager.LoadScene(SIndex);
    }
    public override void OnPauseButton()
    {
        PreviousWindow.SetActive(true);
        PreviousWindow.GetComponent<GenericWindow>().Start();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
