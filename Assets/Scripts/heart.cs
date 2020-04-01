using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    [SerializeField] GameObject HeartOn;
    public bool IsHeartOn = true;
    public void On()
    {
        HeartOn.SetActive(true);
        IsHeartOn = true;
    }
    public void Off()
    {
        HeartOn.SetActive(false);
        IsHeartOn = false;
    }
}
