using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public SoundProperties[] sounds;
    public static AudioManager Instance;
    public AudioMixer MasteMixer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MasteMixer.SetFloat("Background", PlayerPrefsScript.getMastervolume());
        var temp = GetComponent<AudioSource>();
        SetData(ref temp, "Theme");
        temp.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetData(ref AudioSource source, string _name)
    {
        foreach (var s in sounds)
        {
            if (_name == s.Name)
            {
                s.GetSource(source);
                break;
            }
        }
    }
}
