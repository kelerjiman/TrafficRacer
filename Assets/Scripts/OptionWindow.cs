using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionWindow : GenericWindow
{
    [SerializeField] Slider masterVolume;
    [SerializeField] Toggle mute;
    private int m_KindOfControl = 0;
    public override void Start()
    {
        base.Start();
        OnLoadData();
        Button btn = CloseButton.GetComponent<Button>();
        CloseButton.onClick.AddListener(OnCloseButton);

    }
    public override void OnCloseButton()
    {
        base.OnCloseButton();
        OnSaveButton();
    }
    public void OnLoadData()
    {
        masterVolume.value = PlayerPrefsScript.getMastervolume();
        mute.isOn = PlayerPrefsScript.getMutevolume();
    }
    public void OnSaveButton()
    {
        PlayerPrefsScript.setMastervolume(masterVolume.value);
        PlayerPrefsScript.setMutevolume(mute.isOn);
        PlayerPrefsScript.setKindOfControl(m_KindOfControl);
    }
    public void OnSelectedControl(int index)
    {
        m_KindOfControl = index;
    }
}
