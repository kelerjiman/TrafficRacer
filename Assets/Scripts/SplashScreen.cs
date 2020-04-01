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
            FadeIn();
        if (Input.GetKeyDown(KeyCode.D))
            FadeOut();
    }
    public void FadeOut()
    {
        anim = GetComponent<Animator>();
        defColor.a = 1;
        color.color = defColor;
        anim.SetTrigger(fadeOut);

    }
    public void FadeIn()
    {
        anim = GetComponent<Animator>();
        defColor.a = 0;
        color.color = defColor;
        anim.SetTrigger(fadeIn);
    }
}
