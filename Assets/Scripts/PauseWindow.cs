using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : GenericWindow
{
    [SerializeField] Movement player;
    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<Movement>();
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
        PreviousWindow.GetComponent<IWindowGeneric>().reloadSetting();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public override void reloadSetting()
    {
        base.reloadSetting();
        if(player==null)
        player = FindObjectOfType<Movement>();
        player.gameObject.SetActive(false);
    }
}
