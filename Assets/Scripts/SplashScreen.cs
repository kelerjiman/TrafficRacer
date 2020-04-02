using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    static SplashScreen Instance;
    [SerializeField] Image color;
    Color defColor;
    string fadeOut = "FadeOut";
    string fadeIn = "FadeIn";
    Animator anim;
    bool con;
    private void Start()
    {
        Instance = this;
        anim = GetComponent<Animator>();
        defColor = color.color;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            FadeInOut(true);
        if (Input.GetKeyDown(KeyCode.D))
            FadeInOut(false);
        //Debug.Log(GameManager.Instance.timeTOChangeWindow);
    }
    public void FadeInOut(bool trigger)
    {
        GameManager.Instance.timeTOChangeWindow = false;
        anim = GetComponent<Animator>();
        anim.SetBool("FadeIn",trigger);
    }
    public void toggle()
    {
        GameManager.Instance.timeTOChangeWindow = true;
    }
    //darmorede in fekr shavad

}
