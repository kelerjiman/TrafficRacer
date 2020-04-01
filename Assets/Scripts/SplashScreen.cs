using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] int fadeSpeed = 2;
    Image Image;
    Color fadeIn;
    Color fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();
        fadeIn = Image.color;
        fadeOut = fadeIn;
        fadeOut.a = 0;
    }
    private void OnEnable()
    {
        FadeOut();
    }
    private void OnDisable()
    {
        FadeIn();
    }
    void FadeIn()
    {
        Image.color = Color.Lerp(Image.color, fadeIn, fadeSpeed * Time.deltaTime);
    }
    void FadeOut()
    {
        fadeOut = Image.color;
        fadeOut.a = 0;
        Image.color = Color.Lerp(Image.color, fadeOut, fadeSpeed * Time.deltaTime);
    }
}
