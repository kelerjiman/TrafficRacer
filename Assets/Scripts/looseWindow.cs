using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looseWindow : GenericWindow
{
    public override void Start()
    {
        base.Start();
        CloseButton.gameObject.SetActive(false);
    }
    public override void OnNextScene(int SIndex)
    {
        GameManager.Instance.GM_Is_Accident = false;
        base.OnNextScene(SIndex);
    }
    public override void reloadSetting()
    {
        GameManager.Instance.player.gameObject.SetActive(false);
        base.reloadSetting();

    }
}
