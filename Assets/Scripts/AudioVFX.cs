using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public class AudioVFX : MonoBehaviour
{
    private AudioSource source;
    [SerializeField]
    string Name;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        AudioManager.Instance.SetData(ref source, Name);
    }
    public void PlayOnShot()
    {
        source.PlayOneShot(source.clip);
    }
    public void Play()
    {
        source.Play();
    }
}
