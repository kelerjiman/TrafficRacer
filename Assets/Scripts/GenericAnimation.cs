using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class GenericAnimation : MonoBehaviour
{
    public enum e_TObject
    {
        image,
        text,
        GameObject
    }
    public float during = 0f;
    public e_TObject Types;
    public Color defColor;
    public Color nextColor;


    public int speed;
    private Color m_tempColor;
    private float m_during = 0f;
    private void Start()
    {
    }
    private void Update()
    {
        m_during += Time.deltaTime;
        Handler_State();
    }
    void Handler_State()
    {
        if (Types != e_TObject.GameObject)
            if (m_during >= during)
            {
                //Debug.Log("GenericAnimation--> Handler_State  --> if number 1---> if number 1");
                m_during = 0;
                m_tempColor = defColor;
                defColor = nextColor;
                nextColor = m_tempColor;
            }
            else
            {
                //Debug.Log("GenericAnimation--> Handler_State  --> if number 1 ---> else number 1");
            }
        animationHandler();
    }
    void animationHandler()
    {
        switch (Types)
        {
            case e_TObject.image:
                GetComponent<Image>().color = defColor;
                GetComponent<Image>().color = nextColor;
                break;
            case e_TObject.text:
                GetComponent<Text>().color = defColor;
                GetComponent<Text>().color = nextColor;
                break;
            case e_TObject.GameObject:
                //Debug.Log("speed is :" + speed);
                var x = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(x.x, (x.y + speed * Time.deltaTime), x.z);
                break;

            default:
                break;
        }
    }
}
