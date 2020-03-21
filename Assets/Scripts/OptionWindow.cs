using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OptionWindow : GenericWindow
{
    [SerializeField] Slider masterVolume;
    [SerializeField] Slider sfx;
    [SerializeField] Toggle sfxMute;
    [SerializeField] Toggle mute;
    private int m_KindOfControl = 0;
    SoundProperties[] sounds;
    public override void Start()
    {
        Debug.Log("option start");
        base.Start();
        OnLoadData();
        //Button btn = CloseButton.GetComponent<Button>();
        //CloseButton.onClick.AddListener(() => OnCloseButton());
    }

    public void setSoundSlider(string SName)
    {

        Debug.Log(SName);

        var sounds = AudioManager.Instance.sounds;
        var sound = Array.Find(sounds, _sound => _sound.Name == SName);
        Debug.Log("sound name is : " + sound.Name);
        if (masterVolume.value == -80)
        {
            mute.isOn = true;
            OnMuteChange(SName);
        }
        else
        {
            mute.isOn = false;
            OnMuteChange(SName);
        }
        sound.mixerGroup.audioMixer.SetFloat(sound.mixerGroup.name, masterVolume.value);
        AudioManager.Instance.SetData(ref sound.source, SName);
        OnSaveButton();
    }
    public void OnMuteChange(string SName)
    {
        Debug.Log(SName);

        var sounds = AudioManager.Instance.sounds;
        var sound = Array.Find(sounds, _sound => _sound.Name == SName);
        Debug.Log("sound name is : " + sound.Name);

        sound.mute = (SName == "Theme") ? mute.isOn : sfxMute.isOn;
        Debug.Log("mixer group name is : " + sound.mixerGroup.name);
        float toggle = (sound.mute) ? -80 : masterVolume.value;
        sound.mixerGroup.audioMixer.SetFloat(sound.mixerGroup.name, toggle);
        masterVolume.value = toggle;
        mute.isOn = sound.mute;
        OnSaveButton();
    }
    public void OnLoadData()
    {
        masterVolume.value = PlayerPrefsScript.getMastervolume();
        mute.isOn = PlayerPrefsScript.getMutevolume();
        Debug.Log("============== option Onload ================");
        Debug.Log("master volume in playerPrefs is : "+PlayerPrefsScript.getMastervolume());
        Debug.Log("Mute volume in playerPrefs is : " + PlayerPrefsScript.getMutevolume());
        Debug.Log("============================================");
    }
    public void OnSaveButton()
    {
        Debug.Log("======================== on save Button =======================");
        PlayerPrefsScript.setMastervolume(masterVolume.value);
        PlayerPrefsScript.setMutevolume(mute.isOn);
        PlayerPrefsScript.setKindOfControl(m_KindOfControl);
        PlayerPrefsScript.setSfxMute(false);/*باید ابتدا یک اسلایدر برای آن درست شود */
        PlayerPrefsScript.setSfxVolume(0);/*باید ابتدا یک اسلایدر برای آن درست شود*/
    }
    public void OnSelectedControl(int index)
    {
        m_KindOfControl = index;
    }
    public override void reloadSetting()
    {
        base.reloadSetting();
        OnLoadData();
    }
    public override void OnCloseButton()
    {
        OnSaveButton();
        base.OnCloseButton();
    }
    ..
    //تنظیمات ذخیره نمی شود درست شود
}
