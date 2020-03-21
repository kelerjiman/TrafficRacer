using UnityEngine;
using UnityEngine.Audio;
using System;
[Serializable]
public class SoundProperties
{
    public string Name;
    public AudioClip clip;
    public bool mute=false;
    [Space(2)]
    [Range(0, 1)]
    public float volume;
    [Range(0, 3)]
    public float pitch;
    [Range(0, 1)]
    public float spatialBlend;
    [Space(2)]
    public bool loop;
    public bool playOnAwake;
    public AudioMixerGroup mixerGroup;
    [HideInInspector]
    public AudioSource source;
    public void GetSource(AudioSource s)
    {
        s.clip = clip;
        s.mute = mute;
        s.pitch = pitch;
        s.volume = volume;
        s.loop = loop;
        s.playOnAwake = playOnAwake;
        s.outputAudioMixerGroup = mixerGroup;
        source = s;
        s.spatialBlend = spatialBlend;
    }
    //mute added 
}
