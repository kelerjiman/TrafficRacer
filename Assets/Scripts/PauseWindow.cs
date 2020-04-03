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
    public override void OnPauseButton()
    {
        GameManager.Instance.player.gameObject.SetActive(true);
        base.OnPauseButton();
        Time.timeScale = 1;
    }
}
